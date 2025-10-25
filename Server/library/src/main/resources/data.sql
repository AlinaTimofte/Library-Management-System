INSERT INTO genre (name) VALUES ('Uncategorized');
UPDATE book SET genre_id = 1 WHERE genre_id IS NULL;