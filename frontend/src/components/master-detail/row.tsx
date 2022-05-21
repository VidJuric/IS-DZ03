import React from "react";
import { TableRow, TableCell, IconButton, Collapse, Box } from "@mui/material";
import PropTypes from 'prop-types';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Osoba } from "../../services/types";

interface Props {
    employee: Osoba;
}

const Row: React.FC<Props> = ({ employee }) => {
    const [open, setOpen] = React.useState(false);

    return <React.Fragment>
        <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
            <TableCell>
                <IconButton
                    aria-label="expand row"
                    size="small"
                    onClick={() => setOpen(!open)}
                >
                    {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
                </IconButton>
            </TableCell>
            <TableCell align="center">{employee.oib}</TableCell>
            <TableCell align="center">{employee.ime}</TableCell>
            <TableCell align="center">{employee.prezime}</TableCell>
            <TableCell align="center">{employee.spol}</TableCell>
            <TableCell align="center">{employee.email}</TableCell>
            <TableCell align="center">
                <>
                    <IconButton aria-label="edit">
                        <EditIcon />
                    </IconButton>
                    <IconButton aria-label="delete">
                        <DeleteIcon />
                    </IconButton>
                </>
            </TableCell>
        </TableRow>
        <TableRow>
            <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={7}>
                <Collapse in={open} timeout="auto" unmountOnExit>
                    <Box sx={{ margin: 1 }}>
                        Test
                    </Box>
                </Collapse>
            </TableCell>
        </TableRow>
    </React.Fragment>
}

Row.propTypes = {
    employee: PropTypes.shape({
        oib: PropTypes.string.isRequired,
        ime: PropTypes.string.isRequired,
        prezime: PropTypes.string.isRequired,
        datumRodjenja: PropTypes.instanceOf(Date).isRequired,
        spol: PropTypes.string.isRequired,
        datumZaposlenja: PropTypes.instanceOf(Date).isRequired,
        email: PropTypes.string.isRequired,
        // history: PropTypes.arrayOf(
        //     PropTypes.shape({
        //         amount: PropTypes.number.isRequired,
        //         customerId: PropTypes.string.isRequired,
        //         date: PropTypes.string.isRequired,
        //     }),
        // ).isRequired,
    }).isRequired,
};

export default Row;