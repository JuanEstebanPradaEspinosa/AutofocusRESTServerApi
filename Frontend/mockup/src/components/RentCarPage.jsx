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
  const initialCarInfo = {
    brand: "",
    model: "",
    year: "",
    color: "",
    imageUrls: [],
  };

  const [carInfo, setCarInfo] = useState(initialCarInfo);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCarInfo({
      ...carInfo,
      [name]: value,
    });
  };

  const handleImageUpload = (e) => {
    const files = e.target.files;
    const newImageUrls = [...carInfo.imageUrls];

    if (files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        if (newImageUrls.length >= 5) break;
        const file = files[i];
        const reader = new FileReader();
        reader.onload = () => {
          newImageUrls.push(reader.result);
          if (newImageUrls.length <= 5) {
            setCarInfo({
              ...carInfo,
              imageUrls: newImageUrls,
            });
          }
        };
        reader.readAsDataURL(file);
      }
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(carInfo);
    setCarInfo(initialCarInfo); // Clear inputs after submitting
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
            multiple
          />
          <label htmlFor="icon-button-file">
            <IconButton color="primary" component="span">
              <PhotoCamera />
            </IconButton>
            Upload Images (max 5)
          </label>
          <div style={{ display: "flex", flexWrap: "wrap", marginTop: "10px" }}>
            {carInfo.imageUrls.map((url, index) => (
              <img
                key={index}
                src={url}
                alt={`Car ${index + 1}`}
                style={{
                  width: "48%",
                  margin: "1%",
                  borderRadius: "5px",
                }}
              />
            ))}
          </div>
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
