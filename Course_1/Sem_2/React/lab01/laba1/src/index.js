import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import Excange from './Exchange';
import Chess from './Chess';

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

ReactDOM.render(
  <React.StrictMode>   
    <Excange />
  </React.StrictMode>,
  document.getElementById('exchange')
);

ReactDOM.render(
  <React.StrictMode>   
    <Chess />
  </React.StrictMode>,
  document.getElementById('chess')
);


