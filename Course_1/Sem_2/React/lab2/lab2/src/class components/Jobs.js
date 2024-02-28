import React from "react";


class SelectJob extends React.Component{
    constructor(props){
        super(props);
        this.state="";
        this.selected = this.selected.bind(this);//Метод bind() создаёт новую функцию, которая при вызове устанавливает в качестве контекста выполнения this предоставленное значение. В метод также передаётся набор аргументов, которые будут установлены перед переданными в привязанную функцию аргументами при её вызове.
    }
    jobs = [
        { value : "...", job: "Выберите"},
        { value : "Programmer", job: "Программист"},
        { value : "Doctor", job: "Доктор"},
        { value : "Builder", job: "Строитель"},
        { value : "Shaxter", job: "Шахтёр"},
        { value : "Flyer", job: "Лётчик"},
    ]
    selected(elements){
        return this.setState({value: elements.target.value});
    }
    render(){
        return (
            <>
                <h2>Выберите профессию</h2> 
                <select onChange={this.selected}> 
                    {this.jobs.map((item) => {
                        return <option value={item.value}>{item.job}</option>;
                    })}
                </select>
                <JobMenu value={this.state.value} />
            </>
        )
    }
}//onChange возникает когда value меняется 

class JobMenu extends React.Component{
    switchCase () {
        let links = [],
            value = this.props.value;
        switch (value){
            case "Programmer":
                links.push(
                    "https://www.itechart.by/",
                    "https://leverx.ru/",
                    "https://www.itechart.by/",
                    "https://leverx.ru/",
                    "https://www.epam.com/",
                    "https://www.epam.com/",
                    "https://leverx.ru/"
                  );
                  break;
            case "Doctor":
                links.push(
                    "https://doctortut.by/doctors/",
                    "https://lubimydoctor.by/",
                    "https://doctortut.by/doctors/",
                    "https://lubimydoctor.by/",
                    "https://doctortut.by/doctors/",
                    "https://lubimydoctor.by/",
                    "https://doctortut.by/doctors"
                  );
                  break;

            case "Builder":
                links.push(
                        "https://rabota.by/vacancies/stroitel",
                        "https://pubmed.ncbi.nlm.nih.gov/",
                        "https://rabota.by/vacancies/stroitel",
                        "https://www.mayoclinic.org",
                        "https://rabota.by/vacancies/stroitel",
                        "https://www.bmj.com",
                        "https://rabota.by/vacancies/stroitel"
                      );
                      break;

            case "Shaxter":
                links.push(
                            "https://proektoria.online/catalog/professions/shahtyor",
                            "https://pubmed.ncbi.nlm.nih.gov/",
                            "https://proektoria.online/catalog/professions/shahtyor",
                            "https://www.mayoclinic.org",
                            "https://proektoria.online/catalog/professions/shahtyor",
                            "https://www.bmj.com"
                          );
                          break;
            case "Flyer":
                links.push(
                            "https://testpilot.ru/",
                            "https://m.lipetskcity.ru/iblock/news/e/lipeckie_letchiki_uvideli_pervimi_film_o_geroe_rossii_olege_peshkove13-11-2021/",
                            "https://ru.wikipedia.org/wiki/%D0%A1%D0%BF%D0%B8%D1%81%D0%BE%D0%BA_%D0%BB%D1%91%D1%82%D1%87%D0%B8%D0%BA%D0%BE%D0%B2-%D0%BF%D0%B5%D1%80%D0%B5%D0%B1%D0%B5%D0%B6%D1%87%D0%B8%D0%BA%D0%BE%D0%B2_%D0%BF%D0%B5%D1%80%D0%B8%D0%BE%D0%B4%D0%B0_%D1%85%D0%BE%D0%BB%D0%BE%D0%B4%D0%BD%D0%BE%D0%B9_%D0%B2%D0%BE%D0%B9%D0%BD%D1%8B",
                            "https://tolmachevo.ru/name/pokryshkin/kak-stat-letchikom/",
                            "https://tolmachevo.ru/name/pokryshkin/kak-stat-letchikom/",
                            "https://tolmachevo.ru/name/pokryshkin/kak-stat-letchikom/",
                            "https://tolmachevo.ru/name/pokryshkin/kak-stat-letchikom/"
                          );
                          break;

        }
        return (
            <>
              <h2>Сайты рекомендуемые для посещения:</h2>
              <ol>
                {links.map((item) => {
                  return (
                    <li>
                      <a href={item}>{item}</a>
                      </li>
                  );
                })}
              </ol>
            </>
          );
    }
    render() {
        return <>{this.switchCase()}</>;
      }
}

export default SelectJob


//<button onClick={(e) => this.deleteRow(id, e)}>Удалить строку</button>