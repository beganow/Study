import React from "react";
import './Exchange.css';

let response = [{
    stock_name: "EFX",
    company_name: "Equifax Inc",
    price: 163.55,
    currency: "USD",
    change: "+9.03"
}, {
    stock_name: "IRM",
    company_name: "Iron Mountain Inc",
    price: 33.21,
    currency: "USD",
    change: "+1.42"
}, {
    stock_name: "NTAP",
    company_name: "NetApp Inc",
    price: 54.81,
    currency: "USD",
    change: "-6.01"
}, {
    stock_name: "CTL",
    company_name: "Centurylink Inc",
    price: 13.79,
    currency: "USD",
    change: "-1.37"
}]
const redText = {
color: 'red'
}
const greenText = {
    color: 'green'
    }
class Excange extends React.Component{
    render(){
        return(
            <div>
                <table className="exchange" border="1" cellSpacing={"0px"} cellPadding={"4"}> 
                <tr>
                    <th>Stock name</th>
                    <th>Company name</th>
                    <th>Price</th>
                    <th>Currency</th>
                    <th>Change</th>
                </tr>               
                {
                response.map((response, index) => (
                    
                    <tr key={index}>
                        <td>{response.stock_name}</td>
                        <td>{response.company_name}</td>
                        <td>{response.price}</td>
                        <td>{response.currency}</td>
                        <this.Change query = {response}/>
                    </tr>
                    ))}
                    
                    
                </table>
            </div>
        );
    }
    Change(props) {
        const bh = props.query;
        //alert(bh.change);
        if(bh.change < 0)
        {
            return (<td style={redText}>{bh.change}</td>);
        }
        else
        {
            return (<td style={greenText}>{bh.change}</td>);
        }
    }
}
export default Excange;