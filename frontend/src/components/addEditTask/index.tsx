import { Box, Button, Dialog, DialogActions, DialogContent, FormControl, InputLabel, MenuItem, Select, TextField, Typography } from "@mui/material";
import axios from "axios";
import { useFormik } from "formik";
import React from "react";
import * as yup from 'yup';
import { DropdownValues, Zadatak } from "../../services/types";

interface Props {
    task: Zadatak | null;
    zaposlenikID: number;
    taskStatus: DropdownValues[];
    services: DropdownValues[];
    customerSupport: DropdownValues[];
    open: boolean;
    onClose: (value: boolean) => void;
}

const AddEditTask: React.FC<Props> = ({ task, zaposlenikID, taskStatus, services, customerSupport, open, onClose }) => {
    const isAdd: boolean = task ? false : true;

    const validationSchema = yup.object({
        opis: yup.string().required('Opis zadatka je obavezno polje'),
        zaposlenikID: yup.number().required(),
        korisnickasluzbaID: yup.number().required(),
        statusZadatkaID: yup.number().required(),
        uslugaID: yup.number().required()
    })

    const formik = useFormik({
        initialValues: {
            opis: task ? task.opis : '',
            zaposlenikID: zaposlenikID,
            korisnickasluzbaID: task ? task.korisnickasluzbaID : 1,
            statusZadatkaID: task ? task.statusZadatkaID : 1,
            uslugaID: task ? task.uslugaID : 1,
        },
        validationSchema: validationSchema,
        onSubmit: values => {
            if (!isAdd && task) {
                axios.put<Zadatak>(`https://localhost:44312/api/Zadatak/${task.zadatakID}`, values).then(() => {
                    handleClose(true)
                })
            } else {
                axios.post<Zadatak>(`https://localhost:44312/api/Zadatak`, values).then(() => {
                    handleClose(true)
                })
            }
        },
        enableReinitialize: true
    })

    const handleClose = (refresh: boolean) => {
        onClose(refresh)
        formik.resetForm()
    }

    return (
        <Dialog onClose={() => handleClose(false)} open={open} maxWidth="sm" fullWidth>
            <Typography variant="h4" p={1}>
                {isAdd ? 'Add task' : 'Edit task'}
            </Typography>
            <DialogContent>
                <Box
                    m={1}
                    pt={2}
                    sx={{ '& .MuiTextField-root': { my: 2 } }}
                    component="form"
                    onSubmit={formik.handleSubmit}
                    onReset={formik.handleReset}
                    noValidate
                >
                    <TextField
                        fullWidth
                        id="opis"
                        label="Opis zadatka"
                        type="text"
                        name="opis"
                        value={formik.values.opis}
                        onChange={formik.handleChange}
                        error={formik.touched.opis && Boolean(formik.errors.opis)}
                        helperText={formik.touched.opis && formik.errors.opis}
                    />
                    <FormControl fullWidth>
                        <InputLabel>Status zadatka</InputLabel>
                        <Select
                            id="taskStatus"
                            name="statusZadatkaID"
                            value={formik.values.statusZadatkaID}
                            label="statusZadatkaID"
                            onChange={formik.handleChange}
                        >
                            {taskStatus.map(value => (
                                <MenuItem key={value.id} value={value.id}>
                                    {value.value}
                                </MenuItem>
                            ))}
                        </Select>
                    </FormControl>
                    <FormControl sx={{ my: 2 }} fullWidth>
                        <InputLabel>Usluga</InputLabel>
                        <Select
                            id="service"
                            name="uslugaID"
                            value={formik.values.uslugaID}
                            label="uslugaID"
                            onChange={formik.handleChange}
                        >
                            {services.map(value => (
                                <MenuItem key={value.id} value={value.id}>
                                    {value.value}
                                </MenuItem>
                            ))}
                        </Select>
                    </FormControl>
                    <FormControl fullWidth>
                        <InputLabel>Korisnička služba</InputLabel>
                        <Select
                            id="korisnickasluzba"
                            name="korisnickasluzbaID"
                            value={formik.values.korisnickasluzbaID}
                            label="korisnickasluzbaID"
                            onChange={formik.handleChange}
                        >
                            {customerSupport.map(value => (
                                <MenuItem key={value.id} value={value.id}>
                                    {value.value}
                                </MenuItem>
                            ))}
                        </Select>
                    </FormControl>
                    <DialogActions>
                        <Button variant="contained" type="submit">
                            {isAdd ? 'Add' : 'Edit'}
                        </Button>
                        <Button onClick={() => handleClose(false)}>
                            Close
                        </Button>
                    </DialogActions>
                </Box>
            </DialogContent>
        </Dialog>
    )
}

export default AddEditTask;