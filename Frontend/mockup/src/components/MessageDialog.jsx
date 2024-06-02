/* eslint-disable react/prop-types */
// eslint-disable-next-line no-unused-vars
import React, { useState } from "react";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField,
  IconButton,
  Grid,
} from "@mui/material";
import { Send, Chat } from "@mui/icons-material";

export default function MessageDialog({ imageUrl }) {
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState("");

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSend = () => {
    // Handle sending message logic here
    console.log("Sending message:", message);
    setMessage("");
  };

  const handleInputChange = (e) => {
    setMessage(e.target.value);
  };

  return (
    <div>
      <IconButton size="small" color="primary" onClick={handleClickOpen}>
        <Chat />
      </IconButton>
      <Dialog
        open={open}
        onClose={handleClose}
        fullWidth
        maxWidth="sm"
        height="240px"
      >
        <DialogTitle>Let them know you're interested</DialogTitle>
        <DialogContent>
          <Grid container spacing={1} alignItems="center">
            {imageUrl && (
              <Grid
                item
                xs={12}
                style={{ height: "200px", overflow: "hidden" }}
              >
                <img
                  src={imageUrl}
                  alt="Chat"
                  style={{ width: "100%", borderRadius: "10px" }}
                />
              </Grid>
            )}
            <Grid item xs={12}>
              <TextField
                autoFocus
                margin="dense"
                id="message"
                label="Message"
                type="text"
                fullWidth
                variant="outlined"
                value={message}
                onChange={handleInputChange}
                style={{ height: "60px" }}
              />
            </Grid>
          </Grid>
        </DialogContent>
        <DialogActions>
          <IconButton onClick={handleSend} color="primary">
            <Send />
          </IconButton>
          <Button onClick={handleClose} color="primary">
            Close
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
