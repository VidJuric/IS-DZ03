import React, { useEffect, useState } from "react";
import { TableRow, TableCell, IconButton, Collapse, Box, Typography, Table, TableBody, TableHead, Button } from "@mui/material";
import PropTypes from 'prop-types';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { CustomerSupport, DeleteInformation, DropdownValues, Employee, StatusZadatka, Usluga, Zadatak, ZadatakExtended } from "../../services/types";
import axios from "axios";
import { get, find } from 'lodash'
import AddEditTask from "../addEditTask";
import ConfirmationDialog from "../confirmationDialog";

interface Props {
    employee: Employee;
}

const Row: React.FC<Props> = ({ employee }) => {
    const [open, setOpen] = useState(false)
    const [tasks, setTasks] = useState<ZadatakExtended[]>([])
    const [taskStatus, setTaskStatus] = useState<StatusZadatka[]>([])
    const [services, setServices] = useState<Usluga[]>([])
    const [customerSupport, setCustomerSupport] = useState<CustomerSupport[]>([])

    const [taskDialogOpen, setTaskDialogOpen] = useState(false)
    const [selectedTask, setSelectedTask] = useState<Zadatak | null>(null)
    //const [employeeDialogOpen, setEmployeeDialogOpen] = useState(false)

    const [deleteDialog, setDeleteDialog] = useState<boolean>(false)
    const [deleteInformation, setDeleteInformation] = useState<DeleteInformation>({ id: 0, name: '' })

    const handleTaskDialogOpen = (task: Zadatak | null) => {
        setTaskDialogOpen(true);
        setSelectedTask(task);
    };

    const handleTaskDialogClose = (refresh: boolean) => {
        if (refresh) {
            axios.get<Zadatak[]>(`https://localhost:44312/api/Zadatak/${employee.zaposlenikID}`).then(res => {
                const mappedTasks: ZadatakExtended[] = res.data.map(row => {
                    return {
                        ...row,
                        statusZadatka: get(find(taskStatus, { statusZadatkaID: row.statusZadatkaID }), 'opisStatusa', 'Nepoznato'),
                        usluga: get(find(services, { uslugaID: row.uslugaID }), 'opisUsluga', 'Nepoznato'),
                    }
                })
                setTasks(mappedTasks);
            })
        }
        setTaskDialogOpen(false);
    };

    // const handleEmployeeDialogOpen = () => {
    //     setEmployeeDialogOpen(true);
    // };

    // const handleEmployeeDialogClose = () => {
    //     setEmployeeDialogOpen(false);
    // };

    const handleDeleteTaskOpen = (taskID: number, taskName: string) => {
        setDeleteInformation({ id: taskID, name: taskName })
        setDeleteDialog(open)
    }

    const handleDeleteTaskClose = () => {
        setDeleteDialog(false)
    }

    const deleteTask = (taskID: number) => {
        axios.delete(`https://localhost:44312/api/Zadatak/${taskID}`).then(() => {
            axios.get<Zadatak[]>(`https://localhost:44312/api/Zadatak/${employee.zaposlenikID}`).then(res => {
                const mappedTasks: ZadatakExtended[] = res.data.map(row => {
                    return {
                        ...row,
                        statusZadatka: get(find(taskStatus, { statusZadatkaID: row.statusZadatkaID }), 'opisStatusa', 'Nepoznato'),
                        usluga: get(find(services, { uslugaID: row.uslugaID }), 'opisUsluga', 'Nepoznato'),
                    }
                })
                setTasks(mappedTasks);
            })
        })
    }

    useEffect(() => {
        Promise.all([axios.get<Zadatak[]>(`https://localhost:44312/api/Zadatak/${employee.zaposlenikID}`),
        axios.get<StatusZadatka[]>('https://localhost:44312/api/StatusZadatka'),
        axios.get<Usluga[]>('https://localhost:44312/api/Usluga'),
        axios.get<CustomerSupport[]>('https://localhost:44312/api/Osoba/CustomerSupport')])
            .then(([{ data: taskData }, { data: taskStatusData }, { data: serviceData }, { data: customerSupportData }]) => {
                const mappedTasks: ZadatakExtended[] = taskData.map(row => {
                    return {
                        ...row,
                        statusZadatka: get(find(taskStatusData, { statusZadatkaID: row.statusZadatkaID }), 'opisStatusa', 'Nepoznato'),
                        usluga: get(find(serviceData, { uslugaID: row.uslugaID }), 'opisUsluga', 'Nepoznato'),
                    }
                })
                setTasks(mappedTasks);
                setTaskStatus(taskStatusData);
                setServices(serviceData);
                setCustomerSupport(customerSupportData);
            })
    }, [employee.zaposlenikID])

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
                        <Typography variant="h5">
                            Zadaci
                        </Typography>
                        <Button variant="outlined" size="small" onClick={() => handleTaskDialogOpen(null)}>
                            Dodaj novi zadatak
                        </Button>
                        <Table size="small" aria-label="purchases">
                            <TableHead>
                                <TableRow>
                                    <TableCell align="center">Opis</TableCell>
                                    <TableCell align="center">Korisnicka Sluzba</TableCell>
                                    <TableCell align="center">Status Zadatka</TableCell>
                                    <TableCell align="center">Usluga</TableCell>
                                    <TableCell align="center">Actions</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {tasks.map((task) => (
                                    <>
                                        <TableRow key={task.zadatakID}>
                                            <TableCell align="center">{task.opis}</TableCell>
                                            <TableCell align="center">{task.korisnickaSluzbaImePrezime}</TableCell>
                                            <TableCell align="center">{task.statusZadatka}</TableCell>
                                            <TableCell align="center">{task.usluga}</TableCell>
                                            <TableCell align="center">
                                                <>
                                                    <IconButton aria-label="edit" onClick={() => handleTaskDialogOpen(task)}>
                                                        <EditIcon />
                                                    </IconButton>
                                                    <IconButton aria-label="delete" onClick={() => handleDeleteTaskOpen(task.zadatakID, '')}>
                                                        <DeleteIcon />
                                                    </IconButton>
                                                </>
                                            </TableCell>
                                        </TableRow>
                                        <AddEditTask
                                            key={task.opis}
                                            open={taskDialogOpen}
                                            onClose={handleTaskDialogClose}
                                            task={selectedTask}
                                            zaposlenikID={employee.zaposlenikID}
                                            taskStatus={taskStatus.map<DropdownValues>(({ statusZadatkaID, opisStatusa }) => ({ id: statusZadatkaID, value: opisStatusa }))}
                                            services={services.map<DropdownValues>(({ uslugaID, opisUsluga }) => ({ id: uslugaID, value: opisUsluga }))}
                                            customerSupport={customerSupport.map<DropdownValues>(({ korisnickaSluzbaID, ime, prezime }) => ({ id: korisnickaSluzbaID, value: `${ime} ${prezime}` }))}
                                        />
                                        <ConfirmationDialog
                                            open={deleteDialog}
                                            name={deleteInformation.name}
                                            deleteSelected={() => deleteTask(deleteInformation.id)}
                                            onClose={handleDeleteTaskClose}
                                        />
                                    </>
                                ))}
                            </TableBody>
                        </Table>
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
        zaposlenikID: PropTypes.number.isRequired,
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