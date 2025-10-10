package com.example.library.service;

import com.example.library.model.*;
import com.example.library.repository.*;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import java.time.LocalDateTime;

@Service
@Transactional
public class LoanService {
    private final BookRepository bookRepo;
    private final BorrowerRepository borrowerRepo;

    public LoanService(BookRepository bookRepo, BorrowerRepository borrowerRepo) {
        this.bookRepo = bookRepo; this.borrowerRepo = borrowerRepo;
    }

    public Borrower assignBookToBorrower(Long bookId, Long borrowerId, int days) {
        Book b = bookRepo.findById(bookId).orElseThrow();
        if (!b.isAvailable()) throw new IllegalStateException("Cartea nu e disponibilă.");
        Borrower br = borrowerRepo.findById(borrowerId).orElseThrow();

        b.setAvailable(false);
        b.setTotalBorrows(b.getTotalBorrows() + 1);

        br.setCurrentBook(b);
        br.setBorrowedAt(LocalDateTime.now());
        br.setDueAt(LocalDateTime.now().plusDays(days));
        return br; // @Transactional -> salvează
    }

    public Borrower returnBook(Long borrowerId) {
        Borrower br = borrowerRepo.findById(borrowerId).orElseThrow();
        if (br.getCurrentBook() == null) return br;
        Book b = br.getCurrentBook();
        b.setAvailable(true);
        br.setCurrentBook(null);
        br.setBorrowedAt(null);
        br.setDueAt(null);
        return br;
    }
}
