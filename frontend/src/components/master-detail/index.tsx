import React from "react";
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

import { Employee } from "../../services/types";
import Row from "./row";

interface Props {
    employees: Employee[];
}

const MasterDetail: React.FC<Props> = ({ employees }) => {

    return <TableContainer component={Paper}>
        <Table aria-label="collapsible table">
            <TableHead>
                <TableRow>
                    <TableCell />
                    <TableCell align="center">OIB</TableCell>
                    <TableCell align="center">Ime</TableCell>
                    <TableCell align="center">Prezime</TableCell>
                    <TableCell align="center">Spol</TableCell>
                    <TableCell align="center">Email</TableCell>
                    <TableCell align="center">Akcije</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {employees.map((row: Employee, index) => (
                    <Row key={index} employee={row} />
                ))}
            </TableBody>
        </Table>
    </TableContainer>
}

export default MasterDetail;