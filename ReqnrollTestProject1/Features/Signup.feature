Feature: Signup

A short summary of the feature

@tag1
Scenario: Usuario se registra correctamente
	Given El usuario esta en la pagina del Login
	When Ingresa las credenciales de usuario "testing1234a" y el correo "testing1234a@gmail.com"
	And Hacer click en el boton de Signup
	And Ingresa las credenciales de contraseña "testinguno1", el primer nombre "Pablo", el apellido "Perez", la direccion "ESPE", el estado "Sangolqui", la ciudad "Quito", el codigo zip "12345" y el numero telefónico "1234567890"
	And Hacer click en el boton Create Account
	Then Deberia aparecer un mensaje de confirmacion
