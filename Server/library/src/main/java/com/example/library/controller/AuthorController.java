package com.example.library.controller;

import com.example.library.model.Author;
import com.example.library.repository.AuthorRepository;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
@RequestMapping("/api/authors")
@CrossOrigin(origins="http://localhost:5173")
public class AuthorController {
    private final AuthorRepository repo;
    public AuthorController(AuthorRepository repo){this.repo=repo;}

    @GetMapping public List<Author> all(){return repo.findAll();}
    @GetMapping("/{id}") public Author one(@PathVariable Long id){return repo.findById(id).orElseThrow();}
    @PostMapping public Author create(@RequestBody Author a){return repo.save(a);}
    @PutMapping("/{id}") public Author update(@PathVariable Long id,@RequestBody Author a){a.setId(id);return repo.save(a);}
    @DeleteMapping("/{id}") public void delete(@PathVariable Long id){repo.deleteById(id);}
}
