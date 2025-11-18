package com.example.library.service;

import com.example.library.model.Book;
import com.example.library.model.Borrower;
import com.example.library.model.Loan;
import com.example.library.repository.BookRepository;
import com.example.library.repository.BorrowerRepository;
import com.example.library.repository.LoanRepository;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.server.ResponseStatusException;

import java.time.LocalDateTime;

@Service
@Transactional
public class LoanService {
    private final BookRepository bookRepo;
    private final BorrowerRepository borrowerRepo;
    private final LoanRepository loanRepo;

    public LoanService(BookRepository bookRepo, BorrowerRepository borrowerRepo, LoanRepository loanRepo) {
        this.bookRepo = bookRepo;
        this.borrowerRepo = borrowerRepo;
        this.loanRepo = loanRepo;
    }

    public Loan assignBookToBorrower(Long bookId, Long borrowerId, int days) {
        if (loanRepo.existsByBorrowerIdAndBookIdAndReturnedAtIsNull(borrowerId, bookId)) {
            throw new ResponseStatusException(HttpStatus.CONFLICT, "You already have an active loan for this book.");
        }

        Book book = bookRepo.findById(bookId).orElseThrow(() -> new IllegalStateException("Book not found"));
        if (book.getAvailableCopies() <= 0) {
            throw new IllegalStateException("Cartea nu e disponibilă.");
        }
        Borrower borrower = borrowerRepo.findById(borrowerId).orElseThrow(() -> new IllegalStateException("Borrower not found"));

        book.setAvailableCopies(book.getAvailableCopies() - 1);
        book.setTotalBorrows(book.getTotalBorrows() + 1);
        bookRepo.save(book);

        Loan loan = new Loan();
        loan.setBook(book);
        loan.setBorrower(borrower);
        loan.setBorrowedAt(LocalDateTime.now());
        loan.setDueAt(LocalDateTime.now().plusDays(days));

        borrower.getLoans().add(loan);
        borrower.setTotalBorrows(borrower.getTotalBorrows() + 1);

        return loanRepo.save(loan);
    }

    public Loan returnBook(Long loanId) {
        Loan loan = loanRepo.findById(loanId).orElseThrow(() -> new IllegalStateException("Loan not found"));
        if (loan.getReturnedAt() != null) {
            throw new IllegalStateException("Book already returned");
        }

        loan.setReturnedAt(LocalDateTime.now());

        Book book = loan.getBook();
        book.setAvailableCopies(book.getAvailableCopies() + 1);

        return loanRepo.save(loan);
    }
}