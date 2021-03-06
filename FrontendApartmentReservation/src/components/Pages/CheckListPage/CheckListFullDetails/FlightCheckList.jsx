import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import * as actionCreators from '../../../../actions';
import { connect } from 'react-redux';
import { withTranslation } from 'react-i18next';
import { bindActionCreators } from 'redux';import { Link } from 'react-router-dom';
import Checkbox from '@material-ui/core/Checkbox';
import { GridLoader } from 'react-spinners';
import moment from 'moment'
import {BACKEND_URL} from '../../../../actions/index'
import pdf from '../pdf.png';


class FlightCheckList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            flightInfo: {
                isRequired: false,
                flightNumber: '',
                company: '',
                flightTime: '',
                flightDate: '',
                airportAddress: '',
                cost: '',
            },
            flightTicket: {
                file: null
            }
        }

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleTicketSubmit = this.handleTicketSubmit.bind(this);
        this.handleIsRequiredChange = this.handleIsRequiredChange.bind(this);
        this.handleFlightNumberChange = this.handleFlightNumberChange.bind(this);
        this.handleAirportAddressChange = this.handleAirportAddressChange.bind(this);
        this.handleFlightCompanyChange = this.handleFlightCompanyChange.bind(this);
        this.handleFlightTimeChange = this.handleFlightTimeChange.bind(this);
        this.handleFlightDateChange = this.handleFlightDateChange.bind(this);
        this.handleFlightTicketChange = this.handleFlightTicketChange.bind(this);
        this.handleFlightPriceChange = this.handleFlightPriceChange.bind(this);

    }

    componentWillReceiveProps(newProps){
        var currentState = newProps.flightInfo;
        if (newProps.flightInfo.flightTime) {
            var rentStartDateArray = newProps.flightInfo.flightTime.split('T');
            currentState.flightDate = rentStartDateArray[0];
            currentState.flightTime = rentStartDateArray[1];
        }

        this.setState({
            flightInfo: currentState
        })
    }

    handleSubmit(e) {
        e.preventDefault();
        const { flightInfo } = this.state;
        this.props.updateFlightInfo(flightInfo, this.props.employeeId, this.props.tripId);
    }

    handleTicketSubmit(e) {
        e.preventDefault();
        const { flightTicket } = this.state;
        if(this.state.flightTicket.file){
            this.props.uploadFlightTicket(flightTicket.file, this.props.employeeId, this.props.tripId)
        }
    }

    handleIsRequiredChange(e) {
        if(e.target.checked){
            this.props.createFlightInfo(this.props.employeeId, this.props.tripId);
        }
        else{
            this.props.deleteFlightInfo(this.props.employeeId, this.props.tripId);
        }
        var flightInfo = this.state.flightInfo;
        flightInfo.isRequired = e.target.checked;
        this.setState({
            flightInfo: flightInfo
        });
    }

    handleFlightNumberChange(e) {
        var flightInfo = this.state.flightInfo;
        flightInfo.flightNumber = e.target.value;
        this.setState({
            flightInfo: flightInfo
        });
    }

    handleAirportAddressChange(e) {
        var flightInfo = this.state.flightInfo;
        flightInfo.airportAddress = e.target.value;
        this.setState({
            flightInfo: flightInfo
        });
    }

    handleFlightCompanyChange(e) {
        var flightInfo = this.state.flightInfo;
        flightInfo.company = e.target.value;
        this.setState({
            flightInfo: flightInfo
        });
    }

    handleFlightTimeChange(e) {
        var flightInfo = this.state.flightInfo;
        flightInfo.flightTime = e.target.value;
        this.setState({
            flightInfo: flightInfo
        });
    }

    handleFlightDateChange(e) {
        var flightInfo = this.state.flightInfo;
        flightInfo.flightDate = e.target.value;
        this.setState({
            flightInfo: flightInfo
        });
    }

    handleFlightTicketChange(e) {
        var flightTicket = this.state.flightTicket;
        flightTicket.file = e.target.files[0];
        this.setState({
            flightTicket: flightTicket
        });
    }

    handleFlightPriceChange(e) {
        var flightInfo = this.state.flightInfo;
        flightInfo.cost = e.target.value;
        this.setState({
            flightInfo: flightInfo
        })
    }

    render() {
        const { t } = this.props;
        if (this.state.flightInfo) {
            return (
                <div className=" jumbotron mx-auto col-12 col-lg-6 pb-0 mt-0 pt-0 px-0">
                    <div style={{ borderBottom: '1px solid #b4bac4' }}>
                        <label className='pt-2 pl-2'>{t("FlightRequired")}</label>
                        <Checkbox style={{ float: 'right' }} checked={this.state.flightInfo.isRequired} onChange={this.handleIsRequiredChange} />
                    </div>

                    <div className={`loginForm text-center jumbotron mx-auto col-12 col-lg-6 pb-1 mt-0 pt-0`} hidden={!this.state.flightInfo.isRequired}>
                        <form className={`form-signin`} onSubmit={this.handleSubmit} >
                            <div className="form-group mb-2">
                                {t("FlightNumber")}
                                <input type="text" id="FlightNumber" className={`form-control`} placeholder={t("FlightNumber")}
                                    autoFocus name="FlightNumber" value={this.state.flightInfo.flightNumber}
                                    onChange={this.handleFlightNumberChange} />
                            </div>
                            <div className="form-group mb-2">
                                {t("FlightTime")}
                                <input type="date" id="FlightDate" className={`form-control`} placeholder={t("FlightTime")}
                                    name="FlightDate" value={this.state.flightInfo.flightDate}
                                    onChange={this.handleFlightDateChange} />
                            </div>
                            <div className="form-group mb-2">
                                {t("FlightTime")}
                                <input type="time" id="FlightTime" className={`form-control`} placeholder={t("FlightTime")}
                                    name="FlightTime" value={this.state.flightInfo.flightTime}
                                    onChange={this.handleFlightTimeChange} />
                            </div>
                            <div className="form-group mb-2">
                                {t("AirportAddress")}
                                <input type="text" id="AirportAddress" className={`form-control`} placeholder={t("AirportAddress")}
                                    name="AirportAddress" value={this.state.flightInfo.airportAddress}
                                    onChange={this.handleAirportAddressChange} />
                            </div>
                            <div className="form-group">
                                {t("FlightCompany")}
                                <input type="text" id="FlightCompany" className={`form-control`} placeholder={t("FlightCompany")}
                                    name="FlightCompany" value={this.state.flightInfo.company}
                                    onChange={this.handleFlightCompanyChange} />
                            </div>
                            <div className="form-group">
                                {t("Price")}
                                <input type="number" id="FlightPrice" className={`form-control`} placeholder={t("Price")}
                                    name="FlightPrice" value={this.state.flightInfo.cost}
                                    onChange={this.handleFlightPriceChange} />
                            </div>
                            <button className={`btn btn-lg btn-primary btn-block`} type="submit">{t("SaveFlightInfo")}</button>
                        </form>


                        <form className={`form-signin`} encType= "multipart/form-data" onSubmit={this.handleTicketSubmit}>
                            <div className="form-group">
                                <h3>{t("FlightTicket")}</h3>
                                <div className="mt-4 mb-4">
                                    {this.state.flightInfo.ticketFileId &&
                                        <a href={BACKEND_URL + '/files/' + this.state.flightInfo.ticketFileId}>
                                            {t("CurrentFlightTicket")} <img src={pdf} alt="pdf-icon" style={{ height: '32px' }}/>
                                        </a>
                                    }
                                </div>
                                <input type="file" accept="application/pdf" id="FlightTicket" className={`form-control`}
                                    name="FlightTicket"
                                    onChange={this.handleFlightTicketChange} />
                            </div>

                            <button className={`btn btn-lg btn-primary btn-block`} type="submit">{t("SaveTicket")}</button>                            
                        </form>
                    </div>
                </div>
            )
        }
        else {
            return (
                <div className="center-outer-div">
                    <div className='center-div'>
                        <GridLoader
                            sizeUnit={"px"}
                            size={50}
                            color={'red'}
                        />
                    </div>
                </div>
            )
        }
    }
}

const mapDispatchToProps = (dispatch) => {
    return bindActionCreators(actionCreators, dispatch);
}

const mapStateToProps = (state) => {
    return {
    }
}

export default withTranslation()(connect(mapStateToProps, mapDispatchToProps)(FlightCheckList));