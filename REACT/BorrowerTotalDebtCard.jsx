import React, { useState, useEffect } from "react";
import { useFormikContext } from "formik";
import sabioDebug from "sabio-debug";
import Card from "react-bootstrap/Card";
import Logo from "assets/images/brand/logo/MonefiWhiteBGLogo.png";
const _logger = sabioDebug.extend("BorrowerDebt");

const BorrowerTotalDebtCard = () => {
  const [total, setTotal] = useState(0);

  const formikContext = useFormikContext();
  false && _logger(total, setTotal, formikContext.values);

  useEffect(() => {
    _logger("VALUES: ", formikContext.values);
    sumTotalDebt();
  }, [formikContext.values]);

  const sumTotalDebt = () => {
    const { homeMortgage, carPayments, creditCard, otherLoans } =
      formikContext.values;
    const totalDebt = homeMortgage + carPayments + creditCard + otherLoans;
    setTotal(totalDebt);
  };
  return (
    <>
      <Card style={{ width: "18rem" }}>
        <Card.Img
          variant="top"
          src={Logo}
          style={{ width: "100px" }}
          className="mx-auto"
        />
        <Card.Body>
          <Card.Title className="text-center">
            <h1>Total Debt:</h1>
          </Card.Title>
          <Card.Text className="text-center">
            <h2>${total}</h2>
          </Card.Text>
        </Card.Body>
      </Card>
    </>
  );
};
export default BorrowerTotalDebtCard;
