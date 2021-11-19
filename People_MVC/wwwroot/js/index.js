import React, { Component } from "react";
import { connect } from 'react-redux'
import {
    Table,
    Menu,
    Icon,
    Popup,
    Button,
    Header,
    Input,
    Pagination
} from "semantic-ui-react";
import "semantic-ui-css/semantic.min.css";
import "./DeviceList.css";
import _ from 'lodash'
import { getPeopleList, getPersonInfo, upSort, downSort } from "../action/Action";
import up from '~/images/up.png'
import down from '~/images/down.png'
class DeviceList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            up_down: true
        };
    }
    rank() {
        const { upSort } = this.props;
        const { downSort } = this.props;
        const up_down = !this.state.up_down;
        this.setState({ up_down });
        this.state.up_down ? (upSort(this.props.listPeople)) : (downSort(this.props.listPeople));
    }

    render() {
        let self = this;
        return (
            <div className="device-list-container">
                <Table celled className="result-table">
                    <Table.Header>
                        <Table.Row>
                            <Table.HeaderCell className="totalbox">Name
                                <div className="updownbox" onClick={this.rank.bind(this)}>
                                    <img src={up} className='upbox' />
                                    <img src={down} />
                                </div>
                            </Table.HeaderCell>
                        </Table.Row>
                    </Table.Header>
                </Table>
            </div>
        );
    }
}

const mapDispatchToProp = dispatch => ({
    getPeopleList: self => dispatch(getPeopleList(self)),
    getPersonInfo: (self, peopleList) => dispatch(getPersonInfo(self, peopleList)),
    upSort: peopleList => dispatch(upSort(peopleList)),
    downSort: peopleList => dispatch(downSort(peopleList))
});