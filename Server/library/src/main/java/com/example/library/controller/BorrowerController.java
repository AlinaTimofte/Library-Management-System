package com.example.library.controller;

import com.example.library.model.Borrower;
import com.example.library.model.Loan;
import com.example.library.repository.BorrowerRepository;
import com.example.library.repository.LoanRepository;
import com.example.library.service.LoanService;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDateTime;
import java.util.List;


@RestController
@RequestMapping("/api/borrowers")
@CrossOrigin(origins="http://localhost:5173")
public class BorrowerController {
    private final BorrowerRepository borrowerRepository;
    private final LoanService loanService;
    private final LoanRepository loanRepository;

    @Autowired
    public BorrowerController(BorrowerRepository borrowerRepository, LoanService loanService, LoanRepository loanRepository) {
        this.borrowerRepository = borrowerRepository;
        this.loanService = loanService;
        this.loanRepository = loanRepository;
    }

    @GetMapping
    public List<Borrower> all() {
        return borrowerRepository.findAll();
    }

    @GetMapping("/top-active")
    public List<Borrower> getTopActiveBorrowers() {
        return borrowerRepository.findTop5ByOrderByTotalBorrowsDesc();
    }

    @GetMapping("/{id}")
    public Borrower one(@PathVariable Long id) {
        return borrowerRepository.findById(id).orElseThrow();
    }

    @PostMapping
    public Borrower create(@RequestBody Borrower borrower) {
        return borrowerRepository.findByEmail(borrower.getEmail())
                .orElseGet(() -> {
                    borrower.setId(null);
                    return borrowerRepository.save(borrower);
                });
    }

    @PutMapping("/{id}")
    public Borrower update(@PathVariable Long id, @RequestBody Borrower b) {
        b.setId(id);
        return borrowerRepository.save(b);
    }

    @DeleteMapping("/{id}")
    @Transactional
    public void delete(@PathVariable Long id) {
        borrowerRepository.deleteBorrowHistoryByBorrowerId(id);
        loanRepository.deleteByBorrowerId(id);
        borrowerRepository.deleteById(id);
    }

    @GetMapping("/overdue")
    public List<Loan> getOverdueBorrowers() {
        return loanRepository.findByReturnedAtIsNullAndDueAtBefore(LocalDateTime.now());
    }


    @GetMapping("/{id}/loans")
    public List<Loan> getBorrowerLoans(@PathVariable Long id) {
        return loanRepository.findByBorrowerIdAndReturnedAtIsNull(id);
    }

    @PostMapping("/assign")
    public Loan assign(@RequestParam Long bookId, @RequestParam Long borrowerId, @RequestParam(defaultValue="14") int days) {
        return loanService.assignBookToBorrower(bookId, borrowerId, days);
    }
}