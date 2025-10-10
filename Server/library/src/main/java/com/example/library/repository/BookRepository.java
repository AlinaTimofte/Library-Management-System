package com.example.library.repository;
import com.example.library.model.Book;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.*;
import java.util.*;

public interface BookRepository extends JpaRepository<Book, Long> {
    @Query("select b from Book b order by b.totalBorrows desc")
    List<Book> findMostBorrowed(Pageable pageable);

    List<Book> findByTitleContainingIgnoreCase(String keyword); // pentru filtrare rapidă
}
