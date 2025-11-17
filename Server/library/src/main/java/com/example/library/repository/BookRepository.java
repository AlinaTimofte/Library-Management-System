package com.example.library.repository;
import com.example.library.model.Book;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.*;

import java.util.*;

public interface BookRepository extends JpaRepository<Book, Long> {
<<<<<<< HEAD
    List<Book> findByTitleContainingIgnoreCase(String keyword); // for a better filter
=======
    List<Book> findByTitleContainingIgnoreCase(String keyword); //for better search
>>>>>>> 7e8896f6eaeb727f99ba64333cdd65172b716097

    @Query("SELECT b FROM Book b WHERE b.totalBorrows > 0 ORDER BY b.totalBorrows DESC")
    List<Book> findTop5ByOrderByTotalBorrowsDesc();
    List<Book> findByAuthorId(Long authorId);

}
