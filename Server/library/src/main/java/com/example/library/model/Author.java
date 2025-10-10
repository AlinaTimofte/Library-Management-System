package com.example.library.model;

import jakarta.persistence.*;
import java.util.*;

@Entity
public class Author {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable=false, length=100)
    private String name;

    @OneToMany(mappedBy="author", cascade=CascadeType.ALL, orphanRemoval=true)
    private List<Book> books = new ArrayList<>();

    // getters/setters
    public Long getId(){return id;}
    public void setId(Long id){this.id=id;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public List<Book> getBooks(){return books;}
}
