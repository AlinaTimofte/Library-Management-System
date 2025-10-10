package com.example.library.model;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
public class Borrower {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable=false, length=100)
    private String name;

    @Column(nullable=false, length=150)
    private String email;

    @ManyToOne
    private Book currentBook;           // null dacă nu are carte

    private LocalDateTime borrowedAt;   // null dacă nu are
    private LocalDateTime dueAt;        // null dacă nu are

    // getters/setters
    public Long getId(){return id;}
    public void setId(Long id){this.id=id;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getEmail(){return email;}
    public void setEmail(String email){this.email=email;}
    public Book getCurrentBook(){return currentBook;}
    public void setCurrentBook(Book currentBook){this.currentBook=currentBook;}
    public LocalDateTime getBorrowedAt(){return borrowedAt;}
    public void setBorrowedAt(LocalDateTime borrowedAt){this.borrowedAt=borrowedAt;}
    public LocalDateTime getDueAt(){return dueAt;}
    public void setDueAt(LocalDateTime dueAt){this.dueAt=dueAt;}
}
