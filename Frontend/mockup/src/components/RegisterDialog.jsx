// eslint-disable-next-line no-unused-vars
import React, { useState } from "react";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Link,
  TextField,
} from "@mui/material";
//import LoginDialog from "./LoginDialog";

export default function RegisterDialog() {
  const [open, setOpen] = useState(false);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLoginClick = () => {
    setOpen(true);
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button variant="contained" color="primary" onClick={handleClickOpen}>
        Register
      </Button>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>Register</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Vul hieronder je gegevens in om een account aan te maken.
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            label="Firstname"
            type="text"
            fullWidth
            //value={email}
            //onChange={(e) => setEmail(e.target.value)}
          />
          <TextField
            autoFocus
            margin="dense"
            label="Lastname"
            type="text"
            fullWidth
            //value={email}
            //onChange={(e) => setEmail(e.target.value)}
          />
          <TextField
            autoFocus
            margin="dense"
            label="E-mailadres"
            type="email"
            fullWidth
            //value={email}
            //onChange={(e) => setEmail(e.target.value)}
          />
          <TextField
            margin="dense"
            label="Password"
            type="password"
            fullWidth
            //value={password}
            //onChange={(e) => setPassword(e.target.value)}
          />
          <DialogContentText>
            Already have an account?{" "}
            <Link component="button" variant="body2" onClick={handleLoginClick}>
              Log in here
            </Link>
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button onClick={handleClose} color="primary">
            Register
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
