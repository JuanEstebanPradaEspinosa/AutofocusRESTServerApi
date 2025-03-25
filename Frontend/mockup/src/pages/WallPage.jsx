// eslint-disable-next-line no-unused-vars
import React, { useState } from "react";
import {
  Box,
  Button,
  Grid,
  TextField,
  Typography,
  Snackbar,
  Alert,
  Paper,
  IconButton,
  List,
  ListItem,
  ListItemText,
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";

const WallPage = () => {
  const [posts, setPosts] = useState([]);
  const [name, setName] = useState("");
  const [usageDate, setUsageDate] = useState("");
  const [carModel, setCarModel] = useState("");
  const [carBrand, setCarBrand] = useState("");
  const [carYear, setCarYear] = useState("");
  const [carColor, setCarColor] = useState("");
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [appliedPosts, setAppliedPosts] = useState([]);
  const [openPosts, setOpenPosts] = useState([]);

  // Voor het 'huurder'-gedeelte
  const [userPosts, setUserPosts] = useState([]);
  const [editMode, setEditMode] = useState(false);
  const [editIndex, setEditIndex] = useState(null);

  const handlePost = () => {
    const newPost = {
      id: Date.now(),
      name,
      postedDate: new Date().toLocaleDateString(),
      usageDate,
      car: {
        model: carModel,
        brand: carBrand,
        year: carYear,
        color: carColor,
      },
    };
    setPosts([...posts, newPost]);
    setUserPosts([...userPosts, newPost]); // Voeg post toe aan gebruikersposts
    setOpenPosts([...openPosts, newPost]); // Voeg post toe aan openstaande posts voor verhuurders
    setName("");
    setUsageDate("");
    setCarModel("");
    setCarBrand("");
    setCarYear("");
    setCarColor("");
  };

  const handleEdit = (index) => {
    const postToEdit = userPosts[index];
    setName(postToEdit.name);
    setUsageDate(postToEdit.usageDate);
    setCarModel(postToEdit.car.model);
    setCarBrand(postToEdit.car.brand);
    setCarYear(postToEdit.car.year);
    setCarColor(postToEdit.car.color);
    setEditMode(true);
    setEditIndex(index);
  };

  const handleDelete = (index) => {
    const updatedPosts = [...userPosts];
    updatedPosts.splice(index, 1);
    setUserPosts(updatedPosts);
  };

  const handleUpdate = () => {
    const updatedPosts = [...userPosts];
    updatedPosts[editIndex] = {
      ...updatedPosts[editIndex],
      name,
      usageDate,
      car: {
        model: carModel,
        brand: carBrand,
        year: carYear,
        color: carColor,
      },
    };
    setUserPosts(updatedPosts);
    setEditMode(false);
    setEditIndex(null);
    setName("");
    setUsageDate("");
    setCarModel("");
    setCarBrand("");
    setCarYear("");
    setCarColor("");
  };

  // Voor het 'verhuurder'-gedeelte
  const handleCandidate = (postId) => {
    setOpenSnackbar(true);
  };

  const handleCloseSnackbar = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setOpenSnackbar(false);
  };

  const handleCancelApplication = (postId) => {
    const updatedAppliedPosts = appliedPosts.filter(
      (post) => post.id !== postId
    );
    setAppliedPosts(updatedAppliedPosts);
  };

  // Functie om te solliciteren naar een post
  const handleApply = (postId) => {
    const postToApply = posts.find((post) => post.id === postId);
    if (postToApply) {
      setAppliedPosts([...appliedPosts, postToApply]);
    }
  };

  return (
    <Box p={4}>
      {/* 'huurder' gedeelte */}
      <Typography variant="h4" gutterBottom>
        Wall Page (wat de huurder zou zien)
      </Typography>
      <Grid container spacing={2} justifyContent="center" alignItems="center">
        {/* Inputvelden */}
        <Grid item xs={12} sm={4}>
          <TextField
            label="Name"
            variant="outlined"
            size="small"
            fullWidth
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            label="Date of Usage"
            variant="outlined"
            type="date"
            size="small"
            fullWidth
            InputLabelProps={{
              shrink: true,
            }}
            value={usageDate}
            onChange={(e) => setUsageDate(e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            label="Car Model"
            variant="outlined"
            size="small"
            fullWidth
            value={carModel}
            onChange={(e) => setCarModel(e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            label="Car Brand"
            variant="outlined"
            size="small"
            fullWidth
            value={carBrand}
            onChange={(e) => setCarBrand(e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            label="Car Year"
            variant="outlined"
            size="small"
            fullWidth
            value={carYear}
            onChange={(e) => setCarYear(e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            label="Car Color"
            variant="outlined"
            size="small"
            fullWidth
            value={carColor}
            onChange={(e) => setCarColor(e.target.value)}
          />
        </Grid>
        <Grid item xs={12}>
          {/* Afhankelijk van of we in de bewerkingsmodus zijn, laten we de bijbehorende knoppen zien */}
          {editMode ? (
            <>
              <Button
                variant="contained"
                color="primary"
                onClick={handleUpdate}
              >
                Update
              </Button>
              <Button
                variant="contained"
                color="secondary"
                onClick={() => setEditMode(false)}
              >
                Cancel
              </Button>
            </>
          ) : (
            <Button variant="contained" color="primary" onClick={handlePost}>
              Post
            </Button>
          )}
        </Grid>
      </Grid>

      {/* Overzicht van gemaakte posts */}
      <Box mt={4}>
        <Typography variant="h5" gutterBottom>
          Overzicht van gemaakte posts
        </Typography>
        <Grid container spacing={2}>
          {userPosts.map((post, index) => (
            <Grid item key={post.id} xs={12} sm={6} md={4}>
              <Paper elevation={3} sx={{ p: 2 }}>
                <Typography variant="h6">{post.name}</Typography>
                <Typography variant="subtitle1">
                  Geplaatst op: {post.postedDate}
                </Typography>
                <Typography variant="subtitle1">
                  Gebruiksdatum: {post.usageDate}
                </Typography>
                <Typography variant="body1">
                  Auto te huur: {post.car.brand} {post.car.model} (
                  {post.car.year}, {post.car.color})
                </Typography>
                {/* Toegevoegd: bewerkings- en verwijderingsknoppen */}
                <IconButton onClick={() => handleEdit(index)}>
                  <EditIcon />
                </IconButton>
                <IconButton onClick={() => handleDelete(index)}>
                  <DeleteIcon />
                </IconButton>
              </Paper>
            </Grid>
          ))}
        </Grid>
      </Box>

      {/* Einde 'huurder' gedeelte */}
      <Box borderTop={1} mt={4} pt={4}></Box>

      {/* 'verhuurder' gedeelte */}
      <Grid container spacing={2}>
        {/* Eerste kolom voor posts waarop de verhuurder zich heeft gekandideerd */}
        <Grid item xs={12} sm={6}>
          <Typography variant="h5" gutterBottom>
            Applied Posts
          </Typography>
          <List>
            {appliedPosts.map((post) => (
              <ListItem key={post.id}>
                <ListItemText
                  primary={post.name}
                  secondary={`Usage Date: ${post.usageDate}`}
                />
                <Button
                  variant="contained"
                  color="secondary"
                  onClick={() => handleCancelApplication(post.id)}
                >
                  Cancel Application
                </Button>
              </ListItem>
            ))}
          </List>
        </Grid>
        {/* Tweede kolom voor open posts die nog beschikbaar zijn */}
        <Grid item xs={12} sm={6}>
          <Typography variant="h5" gutterBottom>
            Open Posts
          </Typography>
          <List>
            {openPosts.map((post) => (
              <ListItem key={post.id}>
                <ListItemText
                  primary={post.name}
                  secondary={
                    <>
                      <Typography variant="subtitle2">
                        Posted on: {post.postedDate}
                      </Typography>
                      <Typography variant="subtitle2">
                        Date of Usage: {post.usageDate}
                      </Typography>
                      <Typography variant="body2">
                        Looking to rent: {post.car.brand} {post.car.model} (
                        {post.car.year}, {post.car.color})
                      </Typography>
                    </>
                  }
                />
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => handleApply(post.id)}
                >
                  Apply
                </Button>
              </ListItem>
            ))}
          </List>
        </Grid>
      </Grid>

      <Snackbar
        open={openSnackbar}
        autoHideDuration={6000}
        onClose={handleCloseSnackbar}
      >
        <Alert
          onClose={handleCloseSnackbar}
          severity="success"
          sx={{ width: "100%" }}
        >
          You have successfully applied to rent your car!
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default WallPage;
