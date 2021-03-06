import React from "react";
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as actionCreators from '../../../actions';
import TripCard from './TripCard'
import { withTranslation } from "react-i18next";
import { GridLoader } from 'react-spinners';

class TripsPage extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            updated: false,
            loading: true,
        }

        this.updateState = this.updateState.bind(this);
    }

    componentWillMount() {
        this.props.getAllTrips();
        this.props.clearMergableTrips();
        this.setState({
            loading: true
        })
    }

    updateState(){
        this.setState({
            update: true
        });
    }

    componentWillReceiveProps(newProps){
        this.setState({
            loading: false
        })
    }

    render() {
        const { t } = this.props;
        if ((this.props.trips === [] || this.props.trips.length === 0) && !this.state.loading) {
            return (<div className="row mt-5">
                <div className="col-12">
                    <h1>{t('EmptyTripsList')}</h1>
                </div>
            </div>
            )
        }
        
        if (this.props.trips.length > 0) {
            return (
                <div className="row mt-5">
                    <div className="col-12">
                        <h1 style={{ textAlign: 'center' }}>{t("MyOrganizedTrips")}</h1>
                        <div>
                            {this.props.trips.map(trip => <TripCard key={trip.tripId} trip={trip} mergeable={false} updateState = {this.updateState}/>)}
                        </div>
                    </div>
                </div>
            );
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
        trips: state.trips
    };
}

export default (connect(mapStateToProps, mapDispatchToProps)(withTranslation()(TripsPage)));
