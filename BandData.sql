--run this in TableSql on your Postgres Instance (after a migration)
INSERT INTO bands (name, genre, formed_year, members_count) 
VALUES
  ('Empty Reflection', 'Prog Rock', 2006, 4),
  ('Metallica', 'Heavy Metal', 1981, 4),
  ('Radiohead', 'Alternative Rock', 1985, 5),
  ('Led Zeppelin', 'Rock', 1968, 4),
  ('The Beatles', 'Rock', 1960, 4),
  ('Queen', 'Rock', 1970, 4),
  ('Pink Floyd', 'Progressive Rock', 1965, 4),
  ('Red Hot Chili Peppers', 'Funk Rock', 1983, 4),
  ('BTS ', 'KPOP', 2013, 7),
  ('King Gizzard & the Lizard Wizard', 'Psychedelic rock', 2010, 6),
  ('Gorillaz', 'uhhhhh a genre yes', 1998, 4),
  ('Poindexters Theory', 'Brit Pop', 2001, 3),
  ('Nirvana', 'Grunge', 1987, 3),
  ('Red Hot Chili Peppers', 'Rock Funk', 1982, 4),
  ('Aha', 'Synth Pop', 1982, 3),
  ('Green Day', 'Punk Rock', 1986, 3);

INSERT INTO bandmembers (name, description, fk_band_id) VALUES ('Andy', 'Drums', 1)
INSERT INTO bandmembers (name, description, fk_band_id) VALUES ('Beard', 'Vocal', 1)
INSERT INTO bandmembers (name, description, fk_band_id) VALUES ('Jon', 'Bass', 1)
INSERT INTO bandmembers (name, description, fk_band_id) VALUES ('Nigel', 'Guitar', 1)
      