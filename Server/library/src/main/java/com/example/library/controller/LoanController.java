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


    @PostMapping("/{loanId}/return")
    public Loan returnBook(@PathVariable Long loanId) {
        return loanService.returnBook(loanId);
    }
}
