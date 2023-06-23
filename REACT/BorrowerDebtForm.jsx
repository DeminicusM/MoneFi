import React, { useState } from "react";
import * as borrowerDebtService from "services/borrowerDebtService";
import { Formik, Form, Field, ErrorMessage } from "formik";
import sabioDebug from "sabio-debug";
import toastr from "toastr";
import borrowerDebtSchema from "schemas/borrowerDebtSchema";
import Button from "react-bootstrap/Button";
import "toastr/build/toastr.min.css";
import BorrowerTotalDebtCard from "./BorrowerTotalDebtCard";

const _logger = sabioDebug.extend("BorrowerDebt");

function BorrowerDebtForm() {
  const formData = {
    homeMortgage: 0,
    carPayments: 0,
    creditCard: 0,
    otherLoans: 0,
  };

  const [showBorrowerDebt, setBorrowerDebt] = useState(false);

  const handleSubmit = (values) => {
    _logger("Submit Clicked Now", values);
    borrowerDebtService
      .addBorrowerDebt(values)
      .then(onSuccessBorrowerDebt)
      .catch(onErrorBorrowerDebt);
  };

  const handleToggleAddDebt = () => {
    _logger("Add Debt Clicked");
    setBorrowerDebt(!showBorrowerDebt);
  };

  const onSuccessBorrowerDebt = (response) => {
    _logger(response, "onSuccessBorrowerDebt");
    toastr.success("Debt Successfully Calculated");
  };

  const onErrorBorrowerDebt = (err) => {
    _logger(err, "onErrorBorrowerDebt");
    toastr.error("Debt Unsuccessfully Calculated");
  };

  return (
    <React.Fragment>
      <Formik
        enableReinitialize={true}
        initialValues={formData}
        validationSchema={borrowerDebtSchema}
        onSubmit={handleSubmit}
      >
        <>
          <div className="container">
            <div className="row">
              <div className="col-6">
                <Form className="formik-form">
                  <div className="d-grid gap-2 mt-2">
                    {" "}
                    <Button
                      variant="secondary"
                      size="lg"
                      onClick={handleToggleAddDebt}
                    >
                      Add Debt
                    </Button>
                  </div>{" "}
                  {showBorrowerDebt ? (
                    <div className="mb-3 mt-3">
                      <label htmlFor="inputHomeMortgage" className="form-label">
                        Home Mortgage
                      </label>
                      <Field
                        type="number"
                        className="form-control"
                        id="inputHomeMortgage"
                        aria-describedby="homeMortgageHelp"
                        name="homeMortgage"
                        placeholder="Enter Your Home Mortgage Payment"
                      />
                      <ErrorMessage
                        name="homeMortgage"
                        component="div"
                        className="formik-has-error"
                      />
                    </div>
                  ) : null}
                  {showBorrowerDebt ? (
                    <div className="mb-3">
                      <label htmlFor="inputCarPayments" className="form-label">
                        Car Payments
                      </label>
                      <Field
                        type="number"
                        className="form-control"
                        id="inputCarPayments"
                        aria-describedby="carPaymentsHelp"
                        name="carPayments"
                        placeholder="Enter Your Car Payments"
                      />
                      <ErrorMessage
                        name="carPayments"
                        component="div"
                        className="formik-has-error"
                      />
                    </div>
                  ) : null}
                  {showBorrowerDebt ? (
                    <div className="mb-3">
                      <label htmlFor="inputCreditCard" className="form-label">
                        Credit Card
                      </label>
                      <Field
                        type="number"
                        className="form-control"
                        id="inputCreditCard"
                        aria-describedby="creditCardHelp"
                        name="creditCard"
                        placeholder="Enter Your Credit Card Payments"
                      />
                      <ErrorMessage
                        name="creditCard"
                        component="div"
                        className="formik-has-error"
                      />
                    </div>
                  ) : null}
                  {showBorrowerDebt ? (
                    <div className="mb-3">
                      <label htmlFor="inputOtherLoans" className="form-label">
                        Other Loans
                      </label>
                      <Field
                        type="number"
                        className="form-control"
                        id="inputOtherLoans"
                        aria-describedby="otherLoansHelp"
                        name="otherLoans"
                        placeholder="Enter Your Other Loans"
                      />
                      <ErrorMessage
                        name="otherLoans"
                        component="div"
                        className="formik-has-error"
                      />
                    </div>
                  ) : null}
                  {showBorrowerDebt ? (
                    <button type="submit" className="btn btn-primary">
                      Submit
                    </button>
                  ) : null}
                  {showBorrowerDebt ? (
                    <div className="form-text">
                      We will never share your information with anyone else.
                    </div>
                  ) : null}
                </Form>{" "}
              </div>
              {showBorrowerDebt ? (
                <div className="col-6 d-flex align-items-center justify-content-center">
                  {" "}
                  <BorrowerTotalDebtCard />
                </div>
              ) : null}
            </div>
          </div>
        </>
      </Formik>
    </React.Fragment>
  );
}

export default BorrowerDebtForm;
