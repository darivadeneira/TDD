using System;
using Reqnroll;
using TDDTestingMVC.Models;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class CirculoStepDefinitions
    {
        private readonly AreaCirculo _areaCirculo = new AreaCirculo();
        private double _resultado;


        [Given("El radio del circulo {int}")]
        public void GivenElRadioDelCirculo(double radio)
        {
            _areaCirculo.radio = radio;
        }

        [When("Se calcula el area del circulo")]
        public void WhenSeCalculaElAreaDelCirculo()
        {
            _resultado = _areaCirculo.Area();
        }

        [Then("El area del circulo es {double}")]
        public void ThenElAreaDelCirculoEs(double p0)
        {
            _resultado.CompareTo(p0);
        }
    }
}
