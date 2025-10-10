package com.example.library.model;

import jakarta.persistence.*;

@Entity
public class Book {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable=false, length=150)
    private String title;

    @ManyToOne(optional=false)
    private Author author;

    private boolean available = true;
    private int totalBorrows = 0;

    // getters/setters
    public Long getId(){return id;}
    public void setId(Long id){this.id=id;}
    public String getTitle(){return title;}
    public void setTitle(String title){this.title=title;}
    public Author getAuthor(){return author;}
    public void setAuthor(Author author){this.author=author;}
    public boolean isAvailable(){return available;}
    public void setAvailable(boolean available){this.available=available;}
    public int getTotalBorrows(){return totalBorrows;}
    public void setTotalBorrows(int totalBorrows){this.totalBorrows=totalBorrows;}
}
