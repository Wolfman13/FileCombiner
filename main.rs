use std::{
    fs::{
        File,
        read_dir,
        OpenOptions
    },
    io::{
        prelude::*,
        BufReader,
        stdin
    },
    path::Path,
};

// Reads the file line for line and then writes those lines to a new file.
fn lines_from_file_to_file(filename: impl AsRef<Path>) -> () {
    println!("Opening: {:?}", filename.as_ref());
    
    let file = File::open(filename).expect("No such file");
    let buf = BufReader::new(file);
    let lines: Vec<String> = buf.lines()
        .map(|line| line.expect("Could not parse line"))
        .collect();

    let mut output_file = OpenOptions::new()
        .create(true)
        .append(true)
        .open("Passwords.txt")
        .unwrap();

    for line in lines {
        write!(output_file, "{}", line).unwrap();
    }
}

fn main() {
    for entry in read_dir("./Files/").unwrap() {
        let entry = entry.unwrap();
        lines_from_file_to_file(entry.path());
    }

    println!("Press any key to continue...");
    let mut s: String = String::new();
    stdin().read_line(&mut s).unwrap();
}
