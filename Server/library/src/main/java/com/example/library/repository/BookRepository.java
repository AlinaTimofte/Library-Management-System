package com.example.library.repository;
import com.example.library.model.Book;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.*;

import java.util.*;

public interface BookRepository extends JpaRepository<Book, Long> {
    List<Book> findByTitleContainingIgnoreCase(String keyword); // pentru filtrare rapidă

    @Query("SELECT b FROM Book b WHERE b.totalBorrows > 0 ORDER BY b.totalBorrows DESC")
    List<Book> findTop5ByOrderByTotalBorrowsDesc();

}
