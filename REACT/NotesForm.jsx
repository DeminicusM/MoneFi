import React, { useState, useEffect } from "react";
import sabioDebug from "sabio-debug";
import * as notesService from "services/notesService";
import toastr from "toastr";
import "toastr/build/toastr.min.css";
import { Formik, Form, ErrorMessage } from "formik";
import notesSchema from "schemas/notesSchema";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import "./notes.css";
import Logo from "assets/images/brand/logo/MonefiWhiteBGLogo.png";
import DOMPurify from "dompurify";
import PropTypes from "prop-types";
import ReactQuill from "react-quill";
import "react-quill/dist/quill.snow.css";

const _logger = sabioDebug.extend("Note");

function NotesForm(props) {
  const formData = {
    lectureNotes: "",
    lectureId: props.lectureId,
  };

  _logger("lectureId:", props.lectureId);

  const [showLectureNote, setShowLectureNote] = useState(false);
  const [notes, setNotes] = useState([]);

  useEffect(() => {
    notesService
      .getNoteByLectureId(props.lectureId)
      .then(onGetNoteSuccess)
      .catch(onGetNoteError);
  }, [props.lectureId]);

  const handleToggleAddNote = () => {
    _logger("Add Note Clicked");
    setShowLectureNote(!showLectureNote);
  };

  const handleSave = (values) => {
    _logger("Save Clicked", values);
    notesService
      .addNote(values)
      .then(onSaveSuccessNotes)
      .catch(onSaveErrorNotes);
  };

  const handleDelete = (noteId) => {
    _logger("Delete Clicked", noteId);
    notesService
      .deleteNoteById(noteId)
      .then(() => onDeleteSuccessNotes(noteId))
      .catch(onDeleteErrorNotes);
  };

  const onSaveSuccessNotes = (response) => {
    _logger(response, "onSuccessNotes");
    toastr.success("Note added successfully");
    notesService
      .getNoteByLectureId(props.lectureId)
      .then(onGetNoteSuccess)
      .catch(onGetNoteError);
  };

  const onSaveErrorNotes = (err) => {
    _logger(err, "onErrorNotes");
    toastr.error("Note unsuccessfully added");
  };

  const onGetNoteSuccess = (response) => {
    _logger(response, "Got note successful");
    toastr.success("Lecture Note Shown");
    setNotes(response.items);
  };

  const onGetNoteError = (err) => {
    _logger(err, "Note was not received");
  };

  const onDeleteSuccessNotes = (noteId) => {
    _logger(noteId, "onSuccessNotes");
    toastr.success("Note deleted successfully");
    const filteredNotes = (prevState) =>
      prevState.filter((note) => note.id !== noteId);
    setNotes(filteredNotes);
  };

  const onDeleteErrorNotes = (err) => {
    _logger(err, "onErrorNotes");
    toastr.error("Note unsuccessfully deleted");
  };

  return (
    <React.Fragment>
      <Formik
        enableReinitialize={true}
        initialValues={formData}
        onSubmit={handleSave}
        validationSchema={notesSchema}
      >
        {({ setFieldValue }) => (
          <>
            <div className="container">
              <div className="row">
                <div className="col-6">
                  <Form>
                    <div className="d-grid gap-2">
                      {" "}
                      <Button
                        variant="secondary"
                        size="lg"
                        onClick={handleToggleAddNote}
                      >
                        Add Note
                      </Button>
                    </div>{" "}
                    {showLectureNote ? (
                      <div className="mb-3">
                        <ReactQuill
                          className="form-control"
                          name="lectureNotes"
                          onChange={(value) =>
                            setFieldValue("lectureNotes", value)
                          }
                          theme="snow"
                        />
                        <ErrorMessage
                          name="lectureNotes"
                          component="div"
                          className="formik-has-error"
                        />
                      </div>
                    ) : null}
                    {showLectureNote ? (
                      <button type="submit" className="btn btn-primary">
                        Save
                      </button>
                    ) : null}
                  </Form>
                </div>
              </div>
            </div>
          </>
        )}
      </Formik>

      <div className="card-container mt-2">
        {notes?.map((note) => (
          <Card key={note.id} className={`mb-3 ${note.delete ? "d-none" : ""}`}>
            <Card.Img
              variant="top"
              src={Logo}
              style={{ width: "100px" }}
              className="mx-auto"
            />
            <Card.Body>
              <Card.Title className="text-center">Lecture Note</Card.Title>
              <Card.Text>
                <div
                  dangerouslySetInnerHTML={{
                    __html: DOMPurify.sanitize(note.lectureNotes),
                  }}
                ></div>
              </Card.Text>
              <Button
                variant="warning"
                className="custom-button"
                onClick={() => handleDelete(note.id)}
              >
                Delete
              </Button>
            </Card.Body>
          </Card>
        ))}
      </div>
    </React.Fragment>
  );
}

NotesForm.propTypes = {
  lectureNotes: PropTypes.string.isRequired,
  lectureId: PropTypes.number.isRequired,
};

export default NotesForm;
