package com.example.library.controller;

import com.example.library.model.Loan;
import com.example.library.service.LoanService;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/loans")
@CrossOrigin(origins="http://localhost:5173")
public class LoanController {

    private final LoanService loanService;

    public LoanController(LoanService loanService) {
        this.loanService = loanService;
    }

    // DTO (Data Transfer Object) to represent the request body for borrowing a book
    // The C# client will send a JSON object that matches this structure.
    public static class BorrowRequest {
        public Long bookId;
        public Long borrowerId;
        public int days;
    }

    @PostMapping("/borrow")
    public Loan borrowBook(@RequestBody BorrowRequest request) {
        return loanService.assignBookToBorrower(request.bookId, request.borrowerId, request.days);
    }


    @PostMapping("/{loanId}/return")
    public Loan returnBook(@PathVariable Long loanId) {
        return loanService.returnBook(loanId);
    }
}
