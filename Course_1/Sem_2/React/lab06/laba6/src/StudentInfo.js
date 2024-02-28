import React from "react";

export class StudentInfo extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      FIO: "Obodov Pavel Andreevich",
      birthDate: "03.07.2003",
      uniYear: "2021",
      faculty: "IT",
      group: "2",
      speciality: "ISIT",
      email: "qwerty@mail.ru",
      phoneNumber: "80295234567",
    };
  }
  render() {
      return(
          this.props.render(this.state)
      )
  }
}
