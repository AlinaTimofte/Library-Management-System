package com.example.library.model;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
public class Borrower {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable=false, length=100)
    private String name;

    @Column(nullable=false, length=150)
    private String email;

    @Column(nullable = false)
    private boolean notified = false;

    @Column(nullable = false)
    private int totalBorrows = 0;

    @OneToMany(mappedBy = "borrower", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
    @JsonManagedReference
    private List<Loan> loans = new ArrayList<>();

    // getters/setters
    public int getTotalBorrows() {return totalBorrows;}
    public void setTotalBorrows(int totalBorrows) {this.totalBorrows = totalBorrows;}
    public boolean isNotified() {return notified;}
    public void setNotified(boolean notified) {this.notified = notified;}
    public Long getId(){return id;}
    public void setId(Long id){this.id=id;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getEmail(){return email;}
    public void setEmail(String email){this.email=email;}
    public List<Loan> getLoans() {
        return loans;
    }

    public void setLoans(List<Loan> loans) {
        this.loans = loans;
    }
}
