package com.example.library.controller;

import com.example.library.model.Book;
import com.example.library.model.Borrower;
import com.example.library.repository.BookRepository;
import com.example.library.repository.BorrowerRepository;
import com.example.library.service.LoanService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.time.LocalDateTime;
import java.util.List;

@RestController
@RequestMapping("/api/borrowers")
@CrossOrigin(origins="http://localhost:5173")
public class BorrowerController {
    private final BorrowerRepository repo;
    private final LoanService loan;

    @Autowired
    private BorrowerRepository borrowerRepository;

    @Autowired
    private BookRepository bookRepository;

    public BorrowerController(BorrowerRepository repo, LoanService loan){this.repo=repo; this.loan=loan;}

    @GetMapping("/{id}") public Borrower one(@PathVariable Long id){return repo.findById(id).orElseThrow();}
    //@PostMapping public Borrower create(@RequestBody Borrower b){return repo.save(b);}

    @PostMapping
    public Borrower create(@RequestBody Borrower borrower) {
        if (borrower.getCurrentBook() != null && borrower.getCurrentBook().getId() != null) {
            Book fullBook = bookRepository.findById(borrower.getCurrentBook().getId())
                    .orElseThrow(() -> new RuntimeException("Book not found"));
            borrower.setCurrentBook(fullBook);
        }

        return borrowerRepository.save(borrower);
    }
    @PutMapping("/{id}") public Borrower update(@PathVariable Long id,@RequestBody Borrower b){b.setId(id);return repo.save(b);}
    @DeleteMapping("/{id}") public void delete(@PathVariable Long id){repo.deleteById(id);}

    // CUSTOM 2: cei cu întârzieri
    @GetMapping("/overdue")
    public List<Borrower> overdue(){ return repo.findOverdue(LocalDateTime.now()); }

    @PostMapping("/assign")
    public Borrower assign(@RequestParam Long bookId, @RequestParam Long borrowerId, @RequestParam(defaultValue="14") int days){
        return loan.assignBookToBorrower(bookId, borrowerId, days);
    }

    @PostMapping("/{borrowerId}/return")
    public Borrower returnBook(@PathVariable Long borrowerId){
        return loan.returnBook(borrowerId);
    }

    @GetMapping
    public List<Borrower> all() {
        return borrowerRepository.findByCurrentBookIsNotNull();
    }
}
