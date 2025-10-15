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
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

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
    public List<Map<String, Object>> getOverdueBorrowers() {
        List<Loan> overdueLoans = loanRepository.findByReturnedAtIsNullAndDueAtBefore(LocalDateTime.now());

        // Mark borrowers as notified
        overdueLoans.forEach(loan -> {
            Borrower borrower = loan.getBorrower();
            if (!borrower.isNotified()) {
                borrower.setNotified(true);
                borrowerRepository.save(borrower);
            }
        });

        return overdueLoans.stream().map(loan -> {
            Map<String, Object> map = new HashMap<>();
            Borrower borrower = loan.getBorrower();
            map.put("id", borrower.getId());
            map.put("name", borrower.getName());
            map.put("email", borrower.getEmail());
            map.put("bookTitle", loan.getBook() != null ? loan.getBook().getTitle() : "N/A");
            map.put("dueAt", loan.getDueAt());
            map.put("daysLate", java.time.temporal.ChronoUnit.DAYS.between(loan.getDueAt(), LocalDateTime.now()));
            map.put("message", "📬 Cartea \"" +
                    (loan.getBook() != null ? loan.getBook().getTitle() : "necunoscută") + 
                    "\" trebuia returnată pe " + loan.getDueAt() + ". Vă rugăm să o returnați cât mai curând.");
            return map;
        }).collect(Collectors.toList());
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