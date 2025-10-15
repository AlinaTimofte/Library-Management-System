package com.example.library.repository;

import com.example.library.model.Loan;
import org.springframework.data.jpa.repository.JpaRepository;

import org.springframework.data.jpa.repository.Modifying;

import java.time.LocalDateTime;
import java.util.List;

public interface LoanRepository extends JpaRepository<Loan, Long> {
    List<Loan> findByBorrowerIdAndReturnedAtIsNull(Long borrowerId);

    List<Loan> findByReturnedAtIsNullAndDueAtBefore(LocalDateTime dateTime);

    @Modifying
    void deleteByBorrowerId(Long borrowerId);
}