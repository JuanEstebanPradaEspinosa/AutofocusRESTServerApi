import React, { useState } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  IconButton,
} from "@mui/material";
import { PhotoCamera, Close } from "@mui/icons-material";

function RentCarPage({ open, onClose, onSubmit }) {
  const [carInfo, setCarInfo] = useState({
    brand: "",
    model: "",
    year: "",
    color: "",
    imageUrl: "",
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCarInfo({
      ...carInfo,
      [name]: value,
    });
  };

  const handleImageUpload = (e) => {
    const file = e.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      setCarInfo({
        ...carInfo,
        imageUrl: reader.result,
      });
    };
    reader.readAsDataURL(file);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(carInfo);
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
      <DialogTitle>Add Your Car</DialogTitle>
      <DialogContent>
        <form onSubmit={handleSubmit}>
          <TextField
            fullWidth
            label="Brand"
            name="brand"
            value={carInfo.brand}
            onChange={handleInputChange}
            margin="normal"
          />
          <TextField
            fullWidth
            label="Model"
            name="model"
            value={carInfo.model}
            onChange={handleInputChange}
            margin="normal"
          />
          <TextField
            fullWidth
            label="Year"
            name="year"
            value={carInfo.year}
            onChange={handleInputChange}
            margin="normal"
          />
          <TextField
            fullWidth
            label="Color"
            name="color"
            value={carInfo.color}
            onChange={handleInputChange}
            margin="normal"
          />
          <input
            accept="image/*"
            id="icon-button-file"
            type="file"
            style={{ display: "none" }}
            onChange={handleImageUpload}
          />
          <label htmlFor="icon-button-file">
            <IconButton color="primary" component="span">
              <PhotoCamera />
            </IconButton>
            Upload Image
          </label>
          {carInfo.imageUrl && (
            <img
              src={carInfo.imageUrl}
              alt="Car"
              style={{ width: "100%", marginTop: "10px", borderRadius: "5px" }}
            />
          )}
        </form>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleSubmit} variant="contained" color="primary">
          Add Car
        </Button>
        <Button onClick={onClose} color="primary" endIcon={<Close />}>
          Cancel
        </Button>
      </DialogActions>
    </Dialog>
  );
}

export default RentCarPage;
