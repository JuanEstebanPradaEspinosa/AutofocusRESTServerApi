import React, { useState } from "react";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  CardMedia,
  Typography,
} from "@mui/material";
import { Info } from "@mui/icons-material";

export default function DetailDialog({ imageUrl }) {
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button
        size="small"
        color="primary"
        onClick={handleClickOpen}
        endIcon={<Info />}
      >
        View details
      </Button>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>Car Details</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Here are some details about the car:
          </DialogContentText>
          <CardMedia
            component="img"
            image={imageUrl}
            alt="Car image"
            style={{ width: 300, maxHeight: "auto" }}
          />
          <Typography variant="body1" style={{ marginTop: "15px" }}>
            This car has four wheels and an engine under the hood. At the back
            of the car, there is an exhaust pipe where *vroom vroom* sounds come
            out!
          </Typography>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Close
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
