--DQL

SELECT * FROM Funcionarios;

UPDATE Funcionarios SET Nome = 'Saulo', Sobrenome = 'Santos' WHERE IdFuncionario = 1;

ALTER TABLE Funcionarios 
ADD DataNascimento DATE;


SELECT * FROM Funcionarios
WHERE Nome LIKE '%saulo'; 