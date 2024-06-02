// eslint-disable-next-line no-unused-vars
import React, { useState } from "react";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  TextField,
  Link,
} from "@mui/material";
//import RegisterDialog from "./RegisterDialog"; // Importeer de RegisterDialog component

export default function LoginDialog() {
  const [open, setOpen] = useState(false);
  const [registerOpen, setRegisterOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleRegisterClick = () => {
    setRegisterOpen(true);
  };

  const handleRegisterClose = () => {
    setRegisterOpen(false);
  };

  return (
    <div>
      <Button variant="contained" color="primary" onClick={handleClickOpen}>
        Log in
      </Button>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>Login</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Vul hieronder je e-mailadres en wachtwoord in om in te loggen.
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            label="E-mailadres"
            type="email"
            fullWidth
            // value={email}
            // onChange={(e) => setEmail(e.target.value)}
          />
          <TextField
            margin="dense"
            label="Wachtwoord"
            type="password"
            fullWidth
            // value={password}
            // onChange={(e) => setPassword(e.target.value)}
          />
          {/* Verander de Link om de register dialoog te openen */}
          <Link
            component="button"
            variant="body2"
            onClick={handleRegisterClick}
          >
            Don't have an account? Register here
          </Link>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button onClick={handleClose} color="primary">
            Log in
          </Button>
        </DialogActions>
      </Dialog>
      {/* Render het RegisterDialog component */}
      {/* <RegisterDialog open={registerOpen} handleClose={handleRegisterClose} /> */}
    </div>
  );
}
