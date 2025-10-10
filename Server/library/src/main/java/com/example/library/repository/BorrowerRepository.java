package com.example.library.repository;
import com.example.library.model.Borrower;
import org.springframework.data.jpa.repository.*;
import org.springframework.data.repository.query.Param;
import java.time.LocalDateTime;
import java.util.*;

public interface BorrowerRepository extends JpaRepository<Borrower, Long> {
    @Query("select br from Borrower br where br.currentBook is not null and br.dueAt < :now")
    List<Borrower> findOverdue(@Param("now") LocalDateTime now);
}
