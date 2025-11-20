package com.example.library.service;

import com.example.library.model.Author;
import com.example.library.model.Book;
import com.example.library.model.Genre;
import com.example.library.model.Suggestion;
import com.example.library.repository.AuthorRepository;
import com.example.library.repository.BookRepository;
import com.example.library.repository.GenreRepository;
import com.example.library.repository.SuggestionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

@Service
public class SuggestionService {

    @Autowired
    private SuggestionRepository suggestionRepository;

    @Autowired
    private BookRepository bookRepository;

    @Autowired
    private AuthorRepository authorRepository;

    @Autowired
    private GenreRepository genreRepository;

    public Suggestion createSuggestion(Suggestion suggestion) {
        return suggestionRepository.save(suggestion);
    }

    public List<Suggestion> getAllSuggestions() {
        return suggestionRepository.findAll();
    }

    @Transactional
    public Book approveSuggestion(Long id) {
        Optional<Suggestion> suggestionOpt = suggestionRepository.findById(id);
        if (suggestionOpt.isPresent()) {
            Suggestion suggestion = suggestionOpt.get();

            // Find or create Author
            Author author = authorRepository.findAll().stream()
                    .filter(a -> a.getName().equalsIgnoreCase(suggestion.getAuthor()))
                    .findFirst()
                    .orElseGet(() -> {
                        Author newAuthor = new Author();
                        newAuthor.setName(suggestion.getAuthor());
                        return authorRepository.save(newAuthor);
                    });

            // Find or create Genre
            Genre genre = genreRepository.findAll().stream()
                    .filter(g -> g.getName().equalsIgnoreCase(suggestion.getGenre()))
                    .findFirst()
                    .orElseGet(() -> {
                        Genre newGenre = new Genre();
                        newGenre.setName(suggestion.getGenre());
                        return genreRepository.save(newGenre);
                    });

            // Create Book
            Book book = new Book();
            book.setTitle(suggestion.getTitle());
            book.setAuthor(author);
            book.setGenre(genre);
            book.setDescription(suggestion.getDescription());
            book.setTotalCopies(1);
            book.setAvailableCopies(1);
            book.setTotalBorrows(0);

            bookRepository.save(book);
            suggestionRepository.delete(suggestion);

            return book;
        }
        return null;
    }
    public void deleteSuggestion(Long id) {
        suggestionRepository.deleteById(id);
    }
}
