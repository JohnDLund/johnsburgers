CREATE TABLE burgers(
  id INT AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  price DECIMAL(6,2) NOT NULL,
  PRIMARY KEY(id)
);



INSERT INTO burgers (name, description, price)
VALUES("The Greatest Burger","This is the greatest burger description",9999.99)

-- CREATE TABLE toppings(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   kcal INT NOT NULL,
--   PRIMARY KEY(id)
-- )


-- INSERT INTO toppings(Name, Kcal)
-- VALUES("Cheese", 20)

