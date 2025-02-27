Feature: Login

A short summary of the feature

@tag1
Scenario: Usuario inicia sesion incorrectamente
	Given El usuario esta en la pagina del login
	When Ingresa las credenciales correo "testuser@gmail.com" y la contraseña "pass123"
	And Hacer click en el boton de Login
	Then Deberia ver un mensaje de error
