import Clock from './class components/Clock';
import SelectJob from './class components/Jobs';

function App() {
  return (
    <div className="App">
      <h3>Первое задание</h3>
      <p>
        Время в Минске: <Clock timezone="+10800" format = "12"/>
      </p>
      <p>
        Время в Нью-Йорке:
        <Clock timezone="-14400" format = "24"/>
      </p>
      <p>
        Время в Лондоне:
        <Clock timezone="+7200" format = "24"/>
      </p>
      
      <h3>Второе задание <SelectJob /></h3>
    </div>
  );
}

export default App;
