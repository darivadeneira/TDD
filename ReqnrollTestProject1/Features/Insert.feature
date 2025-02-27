Feature: Insert

A short summary of the feature

@tag1
Scenario: Insertar clientes
	Given Llenar los campos dentro del fromulario
	| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
	| 1593574562 | Murillo   | Penelope | 01/05/2000      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |
	When Registros ingresados en la bd
	| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
	| 1593574562 | Murillo   | Penelope | 01/05/2000      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |
	Then [outcome]
