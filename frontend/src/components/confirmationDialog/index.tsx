import { Button, Dialog, DialogActions, DialogContent, Divider, Typography } from "@mui/material";
import React from "react";

interface Props {
    open: boolean;
    name: string;
    deleteSelected: () => void;
    onClose: () => void;
}

const ConfirmationDialog: React.FC<Props> = ({ open, name, deleteSelected, onClose }) => {
    const handleClose = () => {
        onClose();
    }

    const handleDelete = () => {
        deleteSelected();
        onClose();
    }

    return (
        <Dialog
            open={open}
            onClose={handleClose}
            maxWidth="sm"
            fullWidth
        >
            <Typography variant="h4" p={1}>
                Delete
            </Typography>
            <Divider />
            <DialogContent>
                Are you sure you want to remove {name === '' ? 'task' : name} ?
            </DialogContent>
            <DialogActions>
                <Button variant="contained" onClick={handleDelete}>
                    Confirm
                </Button>
                <Button onClick={handleClose}>
                    Close
                </Button>
            </DialogActions>
        </Dialog>
    )
}

export default ConfirmationDialog;