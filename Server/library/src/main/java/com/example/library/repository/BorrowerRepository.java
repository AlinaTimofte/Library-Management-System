package com.example.library.repository;
import com.example.library.model.Borrower;
import org.springframework.data.jpa.repository.*;
import org.springframework.data.repository.query.Param;
import java.time.LocalDateTime;
import java.util.*;

public interface BorrowerRepository extends JpaRepository<Borrower, Long> {
    List<Borrower> findTop5ByOrderByTotalBorrowsDesc();

    Optional<Borrower> findByEmail(String email);

    @Modifying
    @Query(value = "DELETE FROM borrow_history WHERE borrower_id = :borrowerId", nativeQuery = true)
    void deleteBorrowHistoryByBorrowerId(@Param("borrowerId") Long borrowerId);
}