
import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import styles from './index.less';

const state = {
    DEF: 0,
    DES: 1,
    ASC: 2,
};

const tranformStatus = status => {
    switch (status) {
        case 'e':
            return state.DEF;
        case 'desc':
            return state.DES;
        case 'asc':
            return state.ASC;
        default:
            return state.DEF;
    }
};

export default function SortButton({ children, clickButton, status }) {
    status = tranformStatus(status);

    const changeSortState = newStatus => {
        switch (newStatus) {
            case state.DEF:
                return '0';
            case state.DES:
                return 'desc';
            case state.ASC:
                return 'asc';
            default:
                return 'O';
        }
    };

    return (
        <Fragment>
            <span className={`${status === state.DEF
                ? styles.sortButtonNormal : styles.sortButtonActive
                }`}
            >
            <span onclick={e => {
                e.stopPropagation();
                const newStatus = status === state.DES ? state.ASC : status + 1;
                clickButton(changeSortState(newStatus));
                }}
            >
            {children}
            </span>

            <span className={`${styles.sortIcon}`}>
                    <i className={`iconfont ${status == state.ASC ? styles.active : styles.normal}`}
                    onclick={e => {
                            e.stopPropagation();
                            clickButton('asc');
                    }}>
                    &#xeb8c;
                    </i >
                    <i className={`iconfont ${status === state.DES ? styles.active : styles.normal
                    }`}
                    onClick = {e => {
                        e.stopPropagation(); clickButton('desc');
                    }}>
                    &#xeb8d; </i>
            </span >
            </span >
        </Fragment >);
}

SortButton.propTypes = {
    children: PropTypes.oneOfType([PropTypes.string, PropTypes.node]), status: PropTypes.string, clickButton: PropTypes.func,
};
