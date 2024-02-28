import React from 'react';

class Clock extends React.Component {
    constructor(props) {
        super(props);
        this.state = {date24: this.toOffsetDate(this.props.timezone)};
        this.state = {date12: this.toOffsetDate12(this.props.timezone)};
        
    }

    componentDidMount() {
        this.timerID = setInterval(
            () => this.tick(),
            1000
        );
    }

    componentWillUnmount() {
        clearInterval(this.timerID);
    }
    toOffsetDate(timezone) {
        let d = new Date(new Date().getTime() + (timezone * 1000));
        let hrs = d.getUTCHours();
        let mins =d.getUTCMinutes();
        let secs = d.getUTCSeconds();
        let proverka1 = (mins < 10)? "0"+ mins: mins;
        return `${hrs}:${proverka1}:${secs}`;

    }
    toOffsetDate12(timezone) {
        let d = new Date(new Date().getTime() + (timezone * 1000));
        let hrs = d.getUTCHours();
        let mins = d.getUTCMinutes();
        let secs = d.getUTCSeconds();
        let proverka = (hrs >= 12)? hrs - 12: hrs;
        return `${proverka}:${mins}:${secs}`;
    }

    tick() {
        this.setState({
            date24: this.toOffsetDate(this.props.timezone),
            date12: this.toOffsetDate12(this.props.timezone)
        });

    }
    render() {
        return (
            <div>
                <p>{this.state.date24}</p>
                <p>{this.state.date12}</p>
            </div>
        )
    }
}
export default Clock;