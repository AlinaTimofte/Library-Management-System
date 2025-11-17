package com.example.library.controller;

import com.example.library.model.Genre;
import com.example.library.repository.GenreRepository;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/genres")
@CrossOrigin(origins = "http://localhost:5173")
public class GenreController {

    private final GenreRepository repo;

    public GenreController(GenreRepository repo) {
        this.repo = repo;
    }

    @GetMapping
    public List<Genre> all() {
        return repo.findAll();
    }

    @GetMapping("/{id}")
    public Genre one(@PathVariable Long id) {
        return repo.findById(id).orElseThrow();
    }

    @PostMapping
    public Genre create(@RequestBody Genre genre) {
        return repo.save(genre);
    }

    @PutMapping("/{id}")
    public Genre update(@PathVariable Long id, @RequestBody Genre genre) {
        genre.setId(id);
        return repo.save(genre);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        repo.deleteById(id);
    }
}
