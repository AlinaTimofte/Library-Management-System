package com.example.library.repository;
import com.example.library.model.Borrower;
import org.springframework.data.jpa.repository.*;
import org.springframework.data.repository.query.Param;
import java.time.LocalDateTime;
import java.util.*;

public interface BorrowerRepository extends JpaRepository<Borrower, Long> {
    @Query(value = "SELECT * FROM borrower ORDER BY total_borrows DESC LIMIT 5", nativeQuery = true)
    List<Borrower> findTop5ActiveBorrowersNative();

    @Query("SELECT DISTINCT l.borrower FROM Loan l WHERE l.returnedAt IS NULL AND l.dueAt < CURRENT_TIMESTAMP")
    List<Borrower> findBorrowersWithOverdueLoans();

    @Query(value = "SELECT * FROM borrower ORDER BY total_borrows DESC LIMIT 5", nativeQuery = true)
    List<Borrower> findTop5ActiveBorrowersNative();

    @Query("SELECT DISTINCT l.borrower FROM Loan l WHERE l.returnedAt IS NULL AND l.dueAt < CURRENT_TIMESTAMP")
    List<Borrower> findBorrowersWithOverdueLoans();

    Optional<Borrower> findByEmail(String email);

    @Modifying
    @Query("DELETE FROM Loan l WHERE l.borrower.id = :borrowerId")
    void deleteAssociatedLoans(@Param("borrowerId") Long borrowerId);
}