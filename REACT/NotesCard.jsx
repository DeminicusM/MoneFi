import React, { useState, useEffect } from "react";
import { useFormikContext } from "formik";
import sabioDebug from "sabio-debug";
import Card from "react-bootstrap/Card";
import Logo from "assets/images/brand/logo/MonefiWhiteBGLogo.png";
import DOMPurify from "dompurify";
const _logger = sabioDebug.extend("Note");

const NotesCard = () => {
  const [note, setNote] = useState(0);

  const formikContext = useFormikContext();
  false && _logger(note, setNote, formikContext.values);

  useEffect(() => {
    _logger("Values: ", formikContext.values);
    showLectureNote();
  }, [formikContext.values]);

  const showLectureNote = () => {
    const { lectureNotes } = formikContext.values;
    const NoteSanitize = DOMPurify.sanitize(lectureNotes);
    setNote(NoteSanitize);
  };

  return (
    <>
      <Card style={{ width: "18rem" }}>
        <Card.Img
          variant="top"
          src={Logo}
          style={{ width: "50px" }}
          className="mx-auto"
        />
        <Card.Body>
          <Card.Title className="text-center">
            <h2>Lecture Note:</h2>
          </Card.Title>
          <Card.Text>
            <div dangerouslySetInnerHTML={{ __html: note }}></div>
          </Card.Text>
        </Card.Body>
      </Card>
    </>
  );
};
export default NotesCard;
