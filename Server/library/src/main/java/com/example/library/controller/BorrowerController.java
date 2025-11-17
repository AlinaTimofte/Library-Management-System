package com.example.library.controller;

import com.example.library.model.Borrower;
import com.example.library.model.Loan;
import com.example.library.model.Book;
import com.example.library.repository.BorrowerRepository;
import com.example.library.repository.LoanRepository;
import com.example.library.repository.BookRepository;
import com.example.library.service.LoanService;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.time.LocalDateTime;
import java.util.List;


@RestController
@RequestMapping("/api/borrowers")
@CrossOrigin(origins="http://localhost:5173")
public class BorrowerController {
    private final BorrowerRepository borrowerRepository;
    private final LoanService loanService;
    private final LoanRepository loanRepository;
    private final BookRepository bookRepository;
    private final PasswordEncoder passwordEncoder = new BCryptPasswordEncoder();

    @Autowired
    public BorrowerController(BorrowerRepository borrowerRepository, LoanService loanService, LoanRepository loanRepository, BookRepository bookRepository) {
        this.borrowerRepository = borrowerRepository;
        this.loanService = loanService;
        this.loanRepository = loanRepository;
        this.bookRepository = bookRepository;
    }

    @GetMapping
    public List<Borrower> all() {
        return borrowerRepository.findAll();
    }

    @GetMapping("/top-active")
    public List<Borrower> getTopActiveBorrowers() {
        return borrowerRepository.findTop5ActiveBorrowersNative();
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

<<<<<<< HEAD
    // Password registration and login
=======
    // --- Password-based registration & login ---
>>>>>>> 7e8896f6eaeb727f99ba64333cdd65172b716097
    public static class RegisterRequest {
        public String name;
        public String email;
        public String password;
    }

    public static class LoginRequest {
        public String email;
        public String password;
    }

    @PostMapping("/register")
    public ResponseEntity<Borrower> register(@RequestBody RegisterRequest req) {
        var existing = borrowerRepository.findByEmail(req.email);
        if (existing.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }

        Borrower b = new Borrower();
        b.setName(req.name);
        b.setEmail(req.email);
        b.setPasswordHash(passwordEncoder.encode(req.password));
        Borrower saved = borrowerRepository.save(b);
        return ResponseEntity.status(HttpStatus.CREATED).body(saved);
    }

    @PostMapping("/login")
    public ResponseEntity<Borrower> login(@RequestBody LoginRequest req) {
        var existing = borrowerRepository.findByEmail(req.email);
        if (existing.isEmpty()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }

        Borrower b = existing.get();
        if (!passwordEncoder.matches(req.password, b.getPasswordHash())) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        return ResponseEntity.ok(b);
    }

    @PutMapping("/{id}")
    public Borrower update(@PathVariable Long id, @RequestBody Borrower b) {
        b.setId(id);
        return borrowerRepository.save(b);
    }

    @DeleteMapping("/{id}")
    @Transactional
    public void delete(@PathVariable Long id) {
        List<Loan> activeLoans = loanRepository.findByBorrowerIdAndReturnedAtIsNull(id);

        for (Loan loan : activeLoans) {
            Book book = loan.getBook();
            book.setAvailableCopies(book.getAvailableCopies() + 1);
            bookRepository.save(book);
        }

        borrowerRepository.deleteAssociatedLoans(id);

        borrowerRepository.deleteById(id);
    }

    @GetMapping("/overdue")
    public List<Loan> getOverdueBorrowers() {
        return loanRepository.findByReturnedAtIsNullAndDueAtBefore(LocalDateTime.now());
    }

    @GetMapping("/overdue-borrowers")
    public List<Borrower> getBorrowersWithOverdueLoans() {
        return borrowerRepository.findBorrowersWithOverdueLoans();
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