package com.example.library.controller;

import com.example.library.model.Book;
import com.example.library.repository.BookRepository;
import org.springframework.data.domain.PageRequest;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
@RequestMapping("/api/books")
@CrossOrigin(origins = "http://localhost:5173")
public class BookController {

    private final BookRepository repo;

    public BookController(BookRepository repo) {
        this.repo = repo;
    }

    @GetMapping
    public List<Book> all() { return repo.findAll(); }

    @GetMapping("/{id}")
    public Book one(@PathVariable Long id) { return repo.findById(id).orElseThrow(); }

    @PostMapping
    public Book create(@RequestBody Book b) { return repo.save(b); }

    @PutMapping("/{id}")
    public Book update(@PathVariable Long id, @RequestBody Book b) {
        b.setId(id);
        return repo.save(b);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) { repo.deleteById(id); }

    @GetMapping("/search")
    public List<Book> search(@RequestParam String q) {
        return repo.findByTitleContainingIgnoreCase(q);
    }

    @GetMapping("/top-borrowed")
    public List<Book> getTopBorrowedBooks() {
        return repo.findTop5ByOrderByTotalBorrowsDesc();
    }

    @GetMapping("/by-author/{authorId}")
    public List<Book> getBooksByAuthor(@PathVariable Long authorId) {
        return repo.findByAuthorId(authorId);
    }

    @PostMapping("/{id}/reserve")
    public Book reserveBook(@PathVariable Long id) {
        Book book = repo.findById(id).orElseThrow();
        if (book.getAvailableCopies() > 0) {
            book.setAvailableCopies(book.getAvailableCopies() - 1);
            return repo.save(book);
        }
        throw new IllegalStateException("Book is not available");
    }
}
