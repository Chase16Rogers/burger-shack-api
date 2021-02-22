USE datachase;
CREATE TABLE sides
(
  id INT AUTO_INCREMENT,
  name  VARCHAR(255) NOT NULL UNIQUE,
  description VARCHAR(255),
  price DECIMAL(6,2) NOT NULL,
  PRIMARY KEY (id)
);
CREATE
INSERT INTO sides
(name, description, price) VALUES ("French Fries", "Nice and crispy", 4.22);